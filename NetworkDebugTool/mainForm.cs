using ClassCollection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace NetworkDebugTool
{
    public partial class MainForm : Form
    {
        private Dictionary<IPAndPort, string> ipList; 
        //本地IP和Port
        private IPAddress localIP;
        private int localPort;
        //远程端口
        private int serverPort;
        private UdpClient udpClient;
        private IPEndPoint iepLocal;
        private Convertion convertion; 
        
        //定义两个委托
        Action<string> textBoxCallback;
        Action<string> listBoxCallback;

        public MainForm()
        {
            InitializeComponent();
            textBoxCallback = new Action<string>(AddtextBoxItem);
            listBoxCallback = new Action<string>(AddListBoxItem);
            ipList = new Dictionary<IPAndPort, string>();
            convertion = new Convertion();
        }

       /// <summary>
       /// 将IP地址和端口显示在列表上
       /// </summary>
       /// <param name="text"></param>
        private void AddListBoxItem(string text)
        {
            if (listRemoteIP.InvokeRequired)
            {
                this.Invoke(listBoxCallback,text);
            }
            else
            {
                listRemoteIP.Items.Add(text);
                listRemoteIP.SelectedIndex = listRemoteIP.Items.Count - 1;
            }
        }


    
        /// <summary>
        /// 将数据添加到textBox即接收文本中
        /// </summary>
        /// <param name="text"></param>
        private void AddtextBoxItem(string text)
        {
            if (textBoxReceive.InvokeRequired)
            {
                this.Invoke(textBoxCallback, text);
            } 
            else
            {
                textBoxReceive.AppendText(text);
                textBoxReceive.AppendText("\n");
            }
        }

        /// <summary>
        /// 接收数据
        /// </summary>
        private void ReceiveData()
        {
            IPAddress remoteIP = null;
            int remotePort = 0;
            IPAndPort remoteIPPort;
            IPEndPoint remote = null;

            while (true)
            {
                try
                {
                    //接收的数据
                    byte[] bytes = udpClient.Receive(ref remote);
                    //远程IP地址和port端口信息
                    remoteIP = remote.Address;
                    remotePort = remote.Port;
                    remoteIPPort = new IPAndPort(remoteIP, remotePort);

                    //如果十六进制显示
                    if (checkBoxDisplay.Checked)
                    { 
                        string hexStr = convertion.ByteToHexStr(bytes);
                        hexStr = convertion.InsertSpace(hexStr);
                        //将远程信息和对应的消息添加到字典中
                       if (!ipList.ContainsKey(remoteIPPort))
                       {
                            string info = DateTime.Now.ToLongTimeString().ToString() + "  " + hexStr+ "\r\n";
                            ipList.Add(remoteIPPort, info); 
                       }
                       //修改字典中string的值
                       else
                       {
                            string newStr;
                            ipList.TryGetValue(remoteIPPort, out newStr);
                            newStr = newStr + DateTime.Now.ToLongTimeString().ToString() + "  " + hexStr+"\r\n";
                            ipList[remoteIPPort] = newStr;
                        }
                        AddtextBoxItem(string.Format(DateTime.Now.ToLongTimeString().ToString() + "  " + "{0}<--{1}", remote, hexStr));
                    }
                    else
                    {  
                        string str = Encoding.Default.GetString(bytes, 0, bytes.Length);
                        if (!ipList.ContainsKey(remoteIPPort))
                        {
                            ipList.Add(remoteIPPort, DateTime.Now.ToLongTimeString().ToString() + "  " + str+"\r\n");
                        }
                        else
                        {
                            string newStr;
                            ipList.TryGetValue(remoteIPPort,out newStr);
                            newStr = newStr + DateTime.Now.ToLongTimeString().ToString() + "  " + str+"\r\n";
                            ipList[remoteIPPort] = newStr;
                        }
                        AddtextBoxItem(string.Format(DateTime.Now.ToLongTimeString().ToString() + "  " + "{0}<--{1}", remote, str));
                    }  
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message+"\n"+"连接已断开");
                    break;
                }
                finally
                {  
                    var keyColl = ipList.Keys;
                    foreach (var ipPort in keyColl)
                    {
                        if (!listRemoteIP.Items.Contains(ipPort.ToString()))
                        {
                            AddListBoxItem(ipPort.ToString());
                        } 
                    }
                }
                Thread.Sleep(50);
            }           
        }

        /// <summary>
        /// 打开连接,接收数据线程开始运行；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ButtonOpenLocal_Click(Object sender,EventArgs e)
        {
            try
            {
                localIP = IPAddress.Parse(localIPText.Text);
                localPort = int.Parse(localPortText.Text);
                iepLocal = new IPEndPoint(localIP, localPort);
                udpClient = new UdpClient(iepLocal);
                buttonOpenLocal.Enabled = false;
                Thread myThread = new Thread(new ThreadStart(ReceiveData));
                myThread.IsBackground = true;
                myThread.Start();
                localSendText.Focus();              
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       /// <summary>
       /// 断开连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ButtonCloseLocal_Click(Object sender, EventArgs e)
        {
            udpClient.Close();
            buttonOpenLocal.Enabled = true;
        }

        /// <summary>
        /// 窗体事件：获取本地IP地址
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Load(object sender, EventArgs e)
        {
            localIPText.Text = convertion.GetIP();
            serverIPText.Text = convertion.GetIP();
        }

        /// <summary>
        /// 发送数据
        /// </summary>
        public void SendData()
        {
            IPAddress remoteIP;
            if(IPAddress.TryParse(serverIPText.Text,out  remoteIP) == false)
            {
                MessageBox.Show("远程IP格式不正确");
                return;
            }
           
            string str = localSendText.Text;
            //如果十六进制发送:需满足十六进制的数据格式
            if (checkBoxSend.Checked) 
            {
                serverPort = int.Parse(serverPortText.Text);
                IPEndPoint sreverIep = new IPEndPoint(remoteIP, serverPort);
                if (convertion.IsHexadecimal(str))
                {
                    MessageBox.Show("不是有效HEX字符组合('0 - 9' 'A - F' 'a - f')");
                    return;
                }               
                try
                {
                    byte[] byteHex = convertion.HexStringToByteArray(str);
                    udpClient.Send(byteHex, byteHex.Length, sreverIep);
                    localSendText.Clear();
                    //如果十六进制显示
                    if (checkBoxDisplay.Checked)
                    {
                        str = convertion.InsertSpace(str);
                        AddtextBoxItem(string.Format(DateTime.Now.ToLongTimeString().ToString() + "  " + "{0}-->{1}", iepLocal, str));
                    }
                    else
                    {
                        AddtextBoxItem(string.Format(DateTime.Now.ToLongTimeString().ToString() + "  " + "{0}-->{1}", iepLocal, Encoding.Default.GetString(byteHex, 0, byteHex.Length)));
                    }
                    localSendText.Focus();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "发送失败");
                }
            }
            else
            {
                byte[] bytes = Encoding.ASCII.GetBytes(str);
                try
                {
                    serverPort = int.Parse(serverPortText.Text);
                    IPEndPoint sreverIep = new IPEndPoint(remoteIP, serverPort);
                    udpClient.Send(bytes, bytes.Length, sreverIep);
                    localSendText.Clear();
                    //如果十六进制显示
                    if (checkBoxDisplay.Checked)
                    {
                        string hexStr = convertion.ByteToHex(bytes);
                        hexStr = convertion.InsertSpace(hexStr);
                        AddtextBoxItem(string.Format(DateTime.Now.ToLongTimeString().ToString() + "  " + "{0}-->{1}", iepLocal, hexStr));
                    }
                    else
                    {
                        AddtextBoxItem(string.Format(DateTime.Now.ToLongTimeString().ToString()+"  "+"{0}-->{1}", iepLocal, str));
                    }
                    //localSendText.Focus();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "发送失败");
                }
                finally
                {
                    
                }
            }          
        }

        /// <summary>
        /// 处理发送按钮事件：发送数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void LocalSendButton_Click(object sender,EventArgs e)
        {
            SendData();
        }

        /// <summary>
        /// 保存数据为文本文件
        /// </summary>
        /// <param name="textBox"></param>
        public void SaveToText(TextBox textBox)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "(*.txt)|*.txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string sPath = sfd.FileName;
                FileStream fs = new FileStream(sPath, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
                foreach (string line in textBox.Lines)
                {
                    sw.WriteLine(line);
                }
                sw.Flush();
                sw.Close();
                fs.Close();
            }
        }

        /// <summary>
        /// 处理菜单事件：将文本保存为文本文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SaveTxtMenu_Click(object sender,EventArgs e)
        {
            SaveToText(textBoxReceive);
        }

        /// <summary>
        /// 将文本保存为二进制文件
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns></returns>
        public bool SaveToBin(TextBox textBox)
        {
            bool isSuccess = false;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "(*.bin)|*.bin";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string sPath = sfd.FileName;
                try
                {
                    Stream flstr = new FileStream(sPath, FileMode.Create);
                    BinaryWriter bw = new BinaryWriter(flstr);
                    foreach (string line in textBox.Lines)
                    {
                        bw.Write(line);
                        isSuccess = true;
                    }
                    bw.Flush();
                    bw.Close();
                    flstr.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("写入文件错误" + e.Message);
                    isSuccess = false;
                }
            }
            return isSuccess;
        }



       /// <summary>
       /// 保存数据为二进制文件
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void SaveBinMenu_Click(object sender, EventArgs e)
        {
            bool isSuccess = SaveToBin(textBoxReceive);
            if(isSuccess == true)
            {
                MessageBox.Show("写入成功");
            }
            else
            {
                MessageBox.Show("写入失败");
            }
        }

        /// <summary>
        /// 处理listBox鼠标事件：显示IP和端口对应的消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListRemoteIP_MouseClick(object sender, MouseEventArgs e)
        {
            int index = listRemoteIP.IndexFromPoint(e.X, e.Y);
            listRemoteIP.SelectedIndex = index;
            if (listRemoteIP.SelectedIndex == 0)
            {
                textBoxReceive.Clear();
                foreach (var kvp in ipList)
                { 
                    
                    string info;
                    ipList.TryGetValue(kvp.Key, out info);
                    info = kvp.Key.ToString()+ "\r\n"+ info;
                    AddtextBoxItem(info);
                }
            }
            if (listRemoteIP.SelectedIndex != -1 && listRemoteIP.SelectedIndex != 0)
            {
                IPAndPort ipPort;   
                //提取listBox中的ip和port
                string ipPortStr= listRemoteIP.SelectedItem.ToString();
                int space = ipPortStr.IndexOf(" ");
                var ipStr = ipPortStr.Substring(0, space);
                var portStr = ipPortStr.Substring(space + 3);
                //以此为检索
                var indexStr = ipStr + ":" + portStr;
                //创建IPAndPort对象
                var ip = IPAddress.Parse(ipStr);
                int port = int.Parse(portStr);
                ipPort = new IPAndPort(ip,port);
                //获取对应IPAndPort的值
                string info;
                ipList.TryGetValue(ipPort, out info);
                textBoxReceive.Clear();
                AddtextBoxItem(info);
            }
        }

        private void textBoxReceive_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }


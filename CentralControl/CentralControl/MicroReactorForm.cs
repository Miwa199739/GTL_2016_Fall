﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GTLutils;
using Instrument;

namespace CentralControl
{
    public partial class MicroReactorForm : Form
    {
        public MicroStorageVirtualDevice mrDevice;
        int CurrentSelected;

        public ControlForm FatherForm;
        public bool IsSocket;

        public MicroReactorForm()
        {
            mrDevice = new MicroStorageVirtualDevice();
            CurrentSelected = 1;
            InitializeComponent();
        }

        //Global_cmd 具体实现的触发事件，将事件添加给委托的语句在ControlForm中。
        public void MicroReactorDevice_cmdEvent()
        {
            currentCmdTextBox.Text = mrDevice.Glb_Cmd;
        }

        private void comboBox1_textChanged(object sender, EventArgs e)
        {
            CurrentSelected = parseInt(this.comboBox1.Text);
            refresh();
        }

        private void MicroReactorForm_Load(object sender, EventArgs e)
        {
            refresh();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            CurrentSelected = parseInt(this.comboBox1.Text);
            showData(CurrentSelected);
            timer1.Start();
        }

        private void showData(int curSelectModule)
        {
            //功能： 根据当前选中的模块，如果模块valid，则显示中控从仪器接收的那些数据，并把按钮2变成停止
            //目前只有 温度，PH和DO
            //如果是invalid，就显示0 ，然后设成开始
          
        }
        private void refresh()
        {
            //根据当前选中的模块，显示中控——>仪器的属性，从自己的变量里读
            //如果该模块valid， 就变成停止
            //如果该模块invalid，就是开始
           
        }



        private void start_Click(object sender, EventArgs e)
        {
            /*一个会在开始和停止之间切换的按钮，应该是标志当前模块是否为开始状态
             * 发了一条SET类型的start给仪器，仪器收到后就会把该模块置为valid，然后回一条response
             顺便把本地的也改成true
             * 反之亦然
             */
            
           
        }

        private void send_Click(object sender, EventArgs e)
        {
            //就是发送一条SET给仪器
        }

        private int parseInt(String text)
        {
            if (text.Equals("模块1")) return 1;
            if (text.Equals("模块2")) return 2;
            if (text.Equals("模块3")) return 3;
            if (text.Equals("模块4")) return 4;
            if (text.Equals("模块5")) return 5;
            if (text.Equals("模块6")) return 6;
            if (text.Equals("模块7")) return 7;
            if (text.Equals("模块8")) return 8;
            return 0;
        }


       


        //global_cmd 设置，可改写对面的事件方法，在特定信息里实例化
        private void send_cmd(String cmd)
        {
            mrDevice.SendModBusMsg(ModbusMessage.MessageType.CMD, "Cmd", cmd);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            send_cmd("Reset");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            send_cmd("Start");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            send_cmd("Stop");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            send_cmd("Auto");
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Diagnostics;

namespace Ciel.Forms
{
    public partial class perf : Form
    {

        PerformanceCounter performanceCPU = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        PerformanceCounter performanceRAM = new PerformanceCounter("Memory", "Available MBytes");
        PerformanceCounter performanceSystem = new PerformanceCounter("System", "System Up Time");

        public perf()
        {
            InitializeComponent();
        }

        private int AnzahlPhysikalischeProzessoren()
        {
            ManagementClass mc = new ManagementClass("Win32_Processor");
            ManagementObjectCollection moc = mc.GetInstances();
            string SocketDesignation = string.Empty;
            List<string> PhysCPU = new List<string>();

            if (!PhysCPU.Contains(SocketDesignation))
            {
                PhysCPU.Add(SocketDesignation);
            }

            return PhysCPU.Count;
        }


        private int AnzahlLogischeProzessoren()
        {
            int LogicalCPU = 0;
            ManagementClass mc = new ManagementClass("Win64_Processor");
            ManagementObjectCollection moc = mc.GetInstances();


            LogicalCPU++;


            return LogicalCPU;
        }



        private void perf_Load(object sender, EventArgs e)
        {
            timer1.Start();

            foreach (var item in new System.Management.ManagementObjectSearcher("Select * from Win32_ComputerSystem").Get())
            {
                lblPhysCPU.Text = "Physical Processors: " + item["NumberOfProcessors"];
            }

            int coreCount = 0;
            foreach (var item in new System.Management.ManagementObjectSearcher("Select * from Win32_Processor").Get())
            {
                coreCount += int.Parse(item["NumberOfCores"].ToString());
            }

            lblCoreCPU.Text = "Cores " + coreCount.ToString();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTimeDate.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();

            lblCPU.Text = "CPU" + " " + (int)performanceCPU.NextValue() + " " + "%";
            lblRAM.Text = "RAM" + " " + (int)performanceRAM.NextValue() + " " + " ";
            lblSystemTime.Text = "Time" + " " + (int)performanceSystem.NextValue() / 60 + " Minutes" + " ";

            lblLogCPU.Text = "Logic Processors " + Environment.ProcessorCount;
        }
    }
}

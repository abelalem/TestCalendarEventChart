
namespace WindowsFormsCalendarEventChart
{
    partial class CalendarEventChart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chartCalendarEvent = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartCalendarEvent)).BeginInit();
            this.SuspendLayout();
            // 
            // chartCalendarEvent
            // 
            this.chartCalendarEvent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chartCalendarEvent.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartCalendarEvent.Legends.Add(legend1);
            this.chartCalendarEvent.Location = new System.Drawing.Point(183, 12);
            this.chartCalendarEvent.Name = "chartCalendarEvent";
            this.chartCalendarEvent.Size = new System.Drawing.Size(509, 417);
            this.chartCalendarEvent.TabIndex = 0;
            this.chartCalendarEvent.Text = "Calendar Event";
            // 
            // CalendarEventChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 441);
            this.Controls.Add(this.chartCalendarEvent);
            this.MinimumSize = new System.Drawing.Size(720, 480);
            this.Name = "CalendarEventChart";
            this.Text = "CalendarEventChart";
            ((System.ComponentModel.ISupportInitialize)(this.chartCalendarEvent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartCalendarEvent;
    }
}
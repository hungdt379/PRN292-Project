
namespace AssignRoom
{
    partial class AssignRoomToClass
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
            this.dateTimeFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTimeTo = new System.Windows.Forms.DateTimePicker();
            this.comboBoxClasses = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxLecturers = new System.Windows.Forms.ComboBox();
            this.lbl = new System.Windows.Forms.Label();
            this.comboBoxSlot = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxRoom = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBoxMonday = new System.Windows.Forms.CheckBox();
            this.checkBoxTuesday = new System.Windows.Forms.CheckBox();
            this.checkBoxWednesday = new System.Windows.Forms.CheckBox();
            this.checkBoxThursday = new System.Windows.Forms.CheckBox();
            this.checkBoxFriday = new System.Windows.Forms.CheckBox();
            this.checkBoxSaturday = new System.Windows.Forms.CheckBox();
            this.checkBoxSunday = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSlotRemain = new System.Windows.Forms.TextBox();
            this.txtNotification = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dateTimeFrom
            // 
            this.dateTimeFrom.Location = new System.Drawing.Point(72, 100);
            this.dateTimeFrom.Name = "dateTimeFrom";
            this.dateTimeFrom.Size = new System.Drawing.Size(200, 20);
            this.dateTimeFrom.TabIndex = 0;
            this.dateTimeFrom.ValueChanged += new System.EventHandler(this.dateTimeFrom_ValueChanged);
            // 
            // dateTimeTo
            // 
            this.dateTimeTo.Location = new System.Drawing.Point(316, 100);
            this.dateTimeTo.Name = "dateTimeTo";
            this.dateTimeTo.Size = new System.Drawing.Size(200, 20);
            this.dateTimeTo.TabIndex = 1;
            this.dateTimeTo.ValueChanged += new System.EventHandler(this.dateTimeTo_ValueChanged);
            // 
            // comboBoxClasses
            // 
            this.comboBoxClasses.FormattingEnabled = true;
            this.comboBoxClasses.Location = new System.Drawing.Point(72, 15);
            this.comboBoxClasses.Name = "comboBoxClasses";
            this.comboBoxClasses.Size = new System.Drawing.Size(121, 21);
            this.comboBoxClasses.TabIndex = 2;
            this.comboBoxClasses.SelectedIndexChanged += new System.EventHandler(this.comboBoxClasses_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(285, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "To";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Class";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(240, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Lecturer";
            // 
            // comboBoxLecturers
            // 
            this.comboBoxLecturers.FormattingEnabled = true;
            this.comboBoxLecturers.Location = new System.Drawing.Point(293, 59);
            this.comboBoxLecturers.Name = "comboBoxLecturers";
            this.comboBoxLecturers.Size = new System.Drawing.Size(121, 21);
            this.comboBoxLecturers.TabIndex = 7;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(33, 143);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(25, 13);
            this.lbl.TabIndex = 8;
            this.lbl.Text = "Slot";
            // 
            // comboBoxSlot
            // 
            this.comboBoxSlot.FormattingEnabled = true;
            this.comboBoxSlot.Location = new System.Drawing.Point(72, 139);
            this.comboBoxSlot.Name = "comboBoxSlot";
            this.comboBoxSlot.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSlot.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Room";
            // 
            // comboBoxRoom
            // 
            this.comboBoxRoom.FormattingEnabled = true;
            this.comboBoxRoom.Location = new System.Drawing.Point(72, 59);
            this.comboBoxRoom.Name = "comboBoxRoom";
            this.comboBoxRoom.Size = new System.Drawing.Size(121, 21);
            this.comboBoxRoom.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(230, 222);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Assign";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBoxMonday
            // 
            this.checkBoxMonday.AutoSize = true;
            this.checkBoxMonday.Enabled = false;
            this.checkBoxMonday.Location = new System.Drawing.Point(37, 178);
            this.checkBoxMonday.Name = "checkBoxMonday";
            this.checkBoxMonday.Size = new System.Drawing.Size(64, 17);
            this.checkBoxMonday.TabIndex = 13;
            this.checkBoxMonday.Text = "Monday";
            this.checkBoxMonday.UseVisualStyleBackColor = true;
            // 
            // checkBoxTuesday
            // 
            this.checkBoxTuesday.AutoSize = true;
            this.checkBoxTuesday.Enabled = false;
            this.checkBoxTuesday.Location = new System.Drawing.Point(104, 178);
            this.checkBoxTuesday.Name = "checkBoxTuesday";
            this.checkBoxTuesday.Size = new System.Drawing.Size(67, 17);
            this.checkBoxTuesday.TabIndex = 14;
            this.checkBoxTuesday.Text = "Tuesday";
            this.checkBoxTuesday.UseVisualStyleBackColor = true;
            // 
            // checkBoxWednesday
            // 
            this.checkBoxWednesday.AutoSize = true;
            this.checkBoxWednesday.Enabled = false;
            this.checkBoxWednesday.Location = new System.Drawing.Point(174, 178);
            this.checkBoxWednesday.Name = "checkBoxWednesday";
            this.checkBoxWednesday.Size = new System.Drawing.Size(83, 17);
            this.checkBoxWednesday.TabIndex = 15;
            this.checkBoxWednesday.Text = "Wednesday";
            this.checkBoxWednesday.UseVisualStyleBackColor = true;
            // 
            // checkBoxThursday
            // 
            this.checkBoxThursday.AutoSize = true;
            this.checkBoxThursday.Enabled = false;
            this.checkBoxThursday.Location = new System.Drawing.Point(261, 178);
            this.checkBoxThursday.Name = "checkBoxThursday";
            this.checkBoxThursday.Size = new System.Drawing.Size(70, 17);
            this.checkBoxThursday.TabIndex = 16;
            this.checkBoxThursday.Text = "Thursday";
            this.checkBoxThursday.UseVisualStyleBackColor = true;
            // 
            // checkBoxFriday
            // 
            this.checkBoxFriday.AutoSize = true;
            this.checkBoxFriday.Enabled = false;
            this.checkBoxFriday.Location = new System.Drawing.Point(334, 178);
            this.checkBoxFriday.Name = "checkBoxFriday";
            this.checkBoxFriday.Size = new System.Drawing.Size(54, 17);
            this.checkBoxFriday.TabIndex = 17;
            this.checkBoxFriday.Text = "Friday";
            this.checkBoxFriday.UseVisualStyleBackColor = true;
            // 
            // checkBoxSaturday
            // 
            this.checkBoxSaturday.AutoSize = true;
            this.checkBoxSaturday.Enabled = false;
            this.checkBoxSaturday.Location = new System.Drawing.Point(391, 178);
            this.checkBoxSaturday.Name = "checkBoxSaturday";
            this.checkBoxSaturday.Size = new System.Drawing.Size(68, 17);
            this.checkBoxSaturday.TabIndex = 19;
            this.checkBoxSaturday.Text = "Saturday";
            this.checkBoxSaturday.UseVisualStyleBackColor = true;
            // 
            // checkBoxSunday
            // 
            this.checkBoxSunday.AutoSize = true;
            this.checkBoxSunday.Enabled = false;
            this.checkBoxSunday.Location = new System.Drawing.Point(462, 178);
            this.checkBoxSunday.Name = "checkBoxSunday";
            this.checkBoxSunday.Size = new System.Drawing.Size(62, 17);
            this.checkBoxSunday.TabIndex = 20;
            this.checkBoxSunday.Text = "Sunday";
            this.checkBoxSunday.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(240, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Slot Remain(s)";
            // 
            // txtSlotRemain
            // 
            this.txtSlotRemain.Location = new System.Drawing.Point(334, 142);
            this.txtSlotRemain.Name = "txtSlotRemain";
            this.txtSlotRemain.ReadOnly = true;
            this.txtSlotRemain.Size = new System.Drawing.Size(100, 20);
            this.txtSlotRemain.TabIndex = 22;
            // 
            // txtNotification
            // 
            this.txtNotification.AutoSize = true;
            this.txtNotification.Location = new System.Drawing.Point(242, 19);
            this.txtNotification.Name = "txtNotification";
            this.txtNotification.Size = new System.Drawing.Size(35, 13);
            this.txtNotification.TabIndex = 23;
            this.txtNotification.Text = "label7";
            // 
            // AssignRoomToClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 259);
            this.Controls.Add(this.txtNotification);
            this.Controls.Add(this.txtSlotRemain);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkBoxSunday);
            this.Controls.Add(this.checkBoxSaturday);
            this.Controls.Add(this.checkBoxFriday);
            this.Controls.Add(this.checkBoxThursday);
            this.Controls.Add(this.checkBoxWednesday);
            this.Controls.Add(this.checkBoxTuesday);
            this.Controls.Add(this.checkBoxMonday);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxRoom);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBoxSlot);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.comboBoxLecturers);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxClasses);
            this.Controls.Add(this.dateTimeTo);
            this.Controls.Add(this.dateTimeFrom);
            this.Name = "AssignRoomToClass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AssignRoomToClass";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimeFrom;
        private System.Windows.Forms.DateTimePicker dateTimeTo;
        private System.Windows.Forms.ComboBox comboBoxClasses;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxLecturers;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.ComboBox comboBoxSlot;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxRoom;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBoxMonday;
        private System.Windows.Forms.CheckBox checkBoxTuesday;
        private System.Windows.Forms.CheckBox checkBoxWednesday;
        private System.Windows.Forms.CheckBox checkBoxThursday;
        private System.Windows.Forms.CheckBox checkBoxFriday;
        private System.Windows.Forms.CheckBox checkBoxSaturday;
        private System.Windows.Forms.CheckBox checkBoxSunday;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSlotRemain;
        private System.Windows.Forms.Label txtNotification;
    }
}
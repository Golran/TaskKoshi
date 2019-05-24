﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace DifferentialEquations.Settings
{
    public static class SettingsForm
    {
        public static SettingsForm<TSettings> For<TSettings>(TSettings settings)
        {
            return new SettingsForm<TSettings>(settings);
        }
    }

    public class SettingsForm<TSettings> : Form
    {
        public SettingsForm(TSettings settings)
        {
            Size = new Size(600, 600);
            BackColor = Color.MediumPurple;
            var okButton = new Button
            {
                Text = "OK",
                DialogResult = DialogResult.OK,
                Dock = DockStyle.Bottom
            };
            Controls.Add(okButton);
            Controls.Add(new PropertyGrid
            {
                SelectedObject = settings,
                Dock = DockStyle.Fill
            });
            AcceptButton = okButton;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Text = "Настройки";
        }
    }
}
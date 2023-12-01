using OWOGame;

namespace OWOAndroid
{
    public partial class MainPage : ContentPage
    {
        static MicroSensation? microSensation;
        int frequency = 100;
        float duration = 1;
        int intensity = 100;
        float rampUp = 0;
        float rampDown = 0;
        public MainPage()
        {
            InitializeComponent();
        }

        private void StartButton_Clicked(object sender, EventArgs e)
        {
            Task.Run(() => OWOConnect());
        }

        private void OWOConnect()
        {
            try
            {
                // OWO.AutoConnect();
                if (OWO.ConnectionState != ConnectionState.Connected)
                {
                    UpdateMessageLabel($"Waiting for Suit Connection {Environment.NewLine}");
                    OWO.AutoConnect();

                    while (OWO.ConnectionState != ConnectionState.Connected)
                    {
                        Thread.Sleep(250);
                    }

                    UpdateMessageLabel($"Suit Connected {Environment.NewLine}");
                }
                else
                {
                    UpdateMessageLabel($"Suit is already Connected {Environment.NewLine}");
                }

                microSensation = SensationsFactory.Create(frequency, duration, intensity, rampUp, rampDown, 0);
            }
            catch (Exception ex)
            {
                UpdateMessageLabel($"Connection Error {ex} {Environment.NewLine}");
            }
        }

        private void UpdateMessageLabel(string message)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                messageLabel.Text += message;
            });
        }
        private void OnIntensityChanged(object sender, TextChangedEventArgs e)
        {
            if (!int.TryParse(e.NewTextValue, out _))
            {
                integerEntryI.Text = string.Empty;
            }
            else
            {
                int.TryParse(e.NewTextValue, out intensity);
                microSensation = SensationsFactory.Create(frequency, duration, intensity, rampUp, rampDown, 0);
            }
        }
        private void OnFrequencyChanged(object sender, TextChangedEventArgs e)
        {
            if (!int.TryParse(e.NewTextValue, out _))
            {
                integerEntryF.Text = string.Empty;
            }
            else
            {
                int.TryParse(e.NewTextValue, out frequency);
                microSensation = SensationsFactory.Create(frequency, duration, intensity, rampUp, rampDown, 0);
            }
        }
        private void OnDurationChanged(object sender, TextChangedEventArgs e)
        {
            if (!float.TryParse(e.NewTextValue, out _))
            {
                integerEntryD.Text = string.Empty;
            }
            else
            {
                float.TryParse(e.NewTextValue, out duration);
                microSensation = SensationsFactory.Create(frequency, duration, intensity, rampUp, rampDown, 0);
            }
        }
        private void OnRampUpChanged(object sender, TextChangedEventArgs e)
        {
            if (!float.TryParse(e.NewTextValue, out _))
            {
                integerEntryRU.Text = string.Empty;
            }
            else
            {
                float.TryParse(e.NewTextValue, out rampUp);
                microSensation = SensationsFactory.Create(frequency, duration, intensity, rampUp, rampDown, 0);
            }
        }
        private void OnRampDownChanged(object sender, TextChangedEventArgs e)
        {
            if (!float.TryParse(e.NewTextValue, out _))
            {
                integerEntryRD.Text = string.Empty;
            }
            else
            {
                float.TryParse(e.NewTextValue, out rampDown);
                microSensation = SensationsFactory.Create(frequency, duration, intensity, rampUp, rampDown, 0);
            }
        }
        private void LeftPectoral_Clicked(object sender, EventArgs e)
        {
            // Your event handling logic for the Left Pectoral button here
            if (microSensation != null)
                OWO.Send(microSensation.WithMuscles(Muscle.Pectoral_L));
            else
            {
                messageLabel.Text += $"Suit is NOT Connected {Environment.NewLine}";
            }
        }

        private void RightPectoral_Clicked(object sender, EventArgs e)
        {
            // Your event handling logic for the Right Pectoral button here
            if (microSensation != null)
                OWO.Send(microSensation.WithMuscles(Muscle.Pectoral_R));
            else
            {
                messageLabel.Text += $"Suit is NOT Connected {Environment.NewLine}";
            }
        }

        private void LeftArm_Clicked(object sender, EventArgs e)
        {
            // Your event handling logic for the Left Arm button here
            if (microSensation != null)
                OWO.Send(microSensation.WithMuscles(Muscle.Arm_L));
            else
            {
                messageLabel.Text += $"Suit is NOT Connected {Environment.NewLine}";
            }
        }
        private void All_Clicked(object sender, EventArgs e)
        {
            // Your event handling logic for the Left Arm button here
            if (microSensation != null)
                OWO.Send(microSensation);
            else
            {
                messageLabel.Text += $"Suit is NOT Connected {Environment.NewLine}";
            }
        }

        private void RightArm_Clicked(object sender, EventArgs e)
        {
            // Your event handling logic for the Right Arm button here
            if (microSensation != null)
                OWO.Send(microSensation.WithMuscles(Muscle.Arm_R));
            else
            {
                messageLabel.Text += $"Suit is NOT Connected {Environment.NewLine}";
            }
        }

        private void LeftAbdominal_Clicked(object sender, EventArgs e)
        {
            // Your event handling logic for the Left Abdominal button here
            if (microSensation != null)
                OWO.Send(microSensation.WithMuscles(Muscle.Abdominal_L));
            else
            {
                messageLabel.Text += $"Suit is NOT Connected {Environment.NewLine}";
            }
        }

        private void RightAbdominal_Clicked(object sender, EventArgs e)
        {
            // Your event handling logic for the Right Abdominal button here
            if (microSensation != null)
                OWO.Send(microSensation.WithMuscles(Muscle.Abdominal_R));
            else
            {
                messageLabel.Text += $"Suit is NOT Connected {Environment.NewLine}";
            }
        }

        private void LeftLumbar_Clicked(object sender, EventArgs e)
        {
            // Your event handling logic for the Left Lumbar button here
            if (microSensation != null)
                OWO.Send(microSensation.WithMuscles(Muscle.Lumbar_L));
            else
            {
                messageLabel.Text += $"Suit is NOT Connected {Environment.NewLine}";
            }
        }

        private void RightLumbar_Clicked(object sender, EventArgs e)
        {
            // Your event handling logic for the Right Lumbar button here
            if (microSensation != null)
                OWO.Send(microSensation.WithMuscles(Muscle.Lumbar_R));
            else
            {
                messageLabel.Text += $"Suit is NOT Connected {Environment.NewLine}";
            }
        }

        private void LeftDorsal_Clicked(object sender, EventArgs e)
        {
            // Your event handling logic for the Left Dorsal button here
            if (microSensation != null)
                OWO.Send(microSensation.WithMuscles(Muscle.Dorsal_L));
            else
            {
                messageLabel.Text += $"Suit is NOT Connected {Environment.NewLine}";
            }
        }

        private void RightDorsal_Clicked(object sender, EventArgs e)
        {
            // Your event handling logic for the Right Dorsal button here
            if (microSensation != null)
                OWO.Send(microSensation.WithMuscles(Muscle.Dorsal_R));
            else
            {
                messageLabel.Text += $"Suit is NOT Connected {Environment.NewLine}";
            }
        }
        private async void HandleConsoleMessage(string message)
        {
            await Dispatcher.DispatchAsync(() =>
            {
                messageLabel.Text += $" Received message: {message} {Environment.NewLine}";
                ScrollLabelToEnd();
            });
        }
        private void ScrollLabelToEnd()
        {
            scrollView.ScrollToAsync(0, messageLabel.Height, true);
        }

        public async void HandleErrorMessage(Exception message)
        {
            await Dispatcher.DispatchAsync(() =>
            {
                messageLabel.Text += Environment.NewLine;
                messageLabel.Text = $"Error: {message.Message} {Environment.NewLine}";
                messageLabel.Text += Environment.NewLine;
            });
        }
    }
}

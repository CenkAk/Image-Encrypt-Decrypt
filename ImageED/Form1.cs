using System;
using System.IO;
using System.Windows.Forms;

namespace ImageED
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                byte[] imageBytes = File.ReadAllBytes(imagePath);
                byte[] encryptedImageBytes = EncryptDecrypt(imageBytes);

                string encryptedImagePath = Path.Combine(Path.GetDirectoryName(imagePath),
                    Path.GetFileNameWithoutExtension(imagePath) + "_encrypted" + Path.GetExtension(imagePath));
                File.WriteAllBytes(encryptedImagePath, encryptedImageBytes);

                MessageBox.Show($"Encrypted image saved to {encryptedImagePath}");
            }
        }

        private void btnDecrypted_Click(object sender , EventArgs e)
        {
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                byte[] imageBytes = File.ReadAllBytes(imagePath);
                byte[] decryptedImageBytes = EncryptDecrypt(imageBytes);

                string decryptedImagePath = Path.Combine(Path.GetDirectoryName(imagePath),
                    Path.GetFileNameWithoutExtension(imagePath) + "_decrypted" + Path.GetExtension(imagePath));
                File.WriteAllBytes(decryptedImagePath, decryptedImageBytes);

                MessageBox.Show($"Decrypted image saved to {decryptedImagePath}");
            }
        }

        private static byte[] EncryptDecrypt(byte[] data)
        {
            byte[] result = new byte[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                result[i] = (byte)(~data[i]);
            }

            return result;
        }
    }
}
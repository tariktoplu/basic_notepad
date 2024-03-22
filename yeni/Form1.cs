/****************************************************************************
**					                SAKARYA ÜNİVERSİTESİ
**				          BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**				                BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**				               NESNEYE DAYALI PROGRAMLAMA DERSİ
**					               2023-2024 BAHAR DÖNEMİ
**	
**				ÖDEV NUMARASI..........: 1
**				ÖĞRENCİ ADI............: Tarık Toplu
**				ÖĞRENCİ NUMARASI.......: 
**              DERSİN ALINDIĞI GRUP...: A (İÖ)
*
****************************************************************************/

using Microsoft.VisualBasic;
using System.Drawing.Printing;
using System.Drawing.Text;

namespace yeni
{
    public partial class Form1 : Form
    {
        private bool dosyaKaydedildi = true;
        private bool DegisiklikYapildi = false;
        private bool changesMade = false;
        private string dosyaYolu = "";



        private PrintDocument printDocument = new PrintDocument();
        public Form1()

        {
            InitializeComponent();
            printDocument.PrintPage += PrintDocument_PrintPage;

            richTextBox1.TextChanged += richTextBox1_TextChanged;
            SetDefaultFont();
            richTextBox1.ContextMenuStrip = contextMenuStrip1;

        }
        private void SetDefaultFont()
        {
            // Windows Not Defteri'nin varsayılan fontunu ve boyutunu kullanarak
            Font defaultFont = new Font("Lucida Console,Regular", 10);

            // RichTextBox'in varsayılan fontunu ayarla
            richTextBox1.Font = defaultFont;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void yeniToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cDosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DosyaOlustur("cs");
        }

        private void cDosyasıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Eğer değişiklik yapıldıysa uyarı veriliyor

            if (DegisiklikYapildi)
            {
                DialogResult result = MessageBox.Show("Dosyada kaydedilmemiş değişiklikler var. Değişiklikleri kaydetmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNoCancel);
                //Evet derse kayıt ediliyor
                if (result == DialogResult.Yes)
                {
                    Kaydet();
                }
                //Cancel'e basarsa iptal ediliyor
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }
            DosyaOlustur("cpp");
        }

        private void cDosyasıToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Eğer değişiklik yapıldıysa uyarı veriliyor

            if (DegisiklikYapildi)
            {
                DialogResult result = MessageBox.Show("Dosyada kaydedilmemiş değişiklikler var. Değişiklikleri kaydetmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNoCancel);
                //Evet derse kayıt ediliyor
                if (result == DialogResult.Yes)
                {
                    Kaydet();
                }
                //Cancel'e basarsa iptal ediliyor
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }
            DosyaOlustur("c");
        }
        private void metinBelgesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Eğer değişiklik yapıldıysa uyarı veriliyor
            if (DegisiklikYapildi)
            {
                DialogResult result = MessageBox.Show("Dosyada kaydedilmemiş değişiklikler var. Değişiklikleri kaydetmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNoCancel);

                //Evet derse kayıt ediliyor
                if (result == DialogResult.Yes)
                {
                    Kaydet();
                }

                //Cancel'e basarsa iptal ediliyor
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }
            DosyaOlustur("txt");
        }

        private void DosyaOlustur(string dosyaUzantisi)
        {
            //Eğer değişiklik yapıldıysa uyarı veriliyor
            if (DegisiklikYapildi)
            {
                DialogResult result = MessageBox.Show("Dosyada kaydedilmemiş değişiklikler var. Değişiklikleri kaydetmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNoCancel);

                //Evet derse kayıt ediliyor
                if (result == DialogResult.Yes)
                {
                    Kaydet();
                }

                //Cancel'e basarsa iptal ediliyor
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }



            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = dosyaUzantisi.ToUpper() + " Dosyaları|*." + dosyaUzantisi;


            //Dosya şablonları için dosya oluşturuluyor
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string dosyaYolu = saveFileDialog.FileName;
                File.Create(dosyaYolu).Close(); // Dosyayı oluştur ve kapat
                MessageBox.Show("Yeni " + dosyaUzantisi.ToUpper() + " dosyası oluşturuldu: " + dosyaYolu);

                // Dosyayı oku ve içeriğini mevcut TextBox'a ekle
                string icerik = "";
                // Dosya uzantısı cpp ise hello world şablonu yazılıyor
                if (dosyaUzantisi == "cpp")
                {
                    icerik = "// C++ Hello World\n#include <iostream>\n\nint main() {\n    std::cout << \"Hello, World!\";\n    return 0;\n}";
                }

                // Dosya uzantısı cs ise ise hello world şablonu yazılıyor
                else if (dosyaUzantisi == "cs")
                {
                    icerik = "// C# Hello World\nusing System;\n\nclass Program\n{\n    static void Main(string[] args)\n    {\n        Console.WriteLine(\"Hello, World!\");\n    }\n}";
                }

                // Dosya uzantısı c ise ise hello world şablonu yazılıyor
                else if (dosyaUzantisi == "c")
                {
                    icerik = "// C Hello World\n#include <stdio.h>\n\nint main() {\n    printf(\"Hello, World!\");\n    return 0;\n}";
                }

                // Dosya uzantısı txt ise ise hello world şablonu yazılıyor
                else if (dosyaUzantisi == "txt")
                {
                    icerik = "Metin Belgesi";
                }

                richTextBox1.Text = icerik;
            }
        }
        private void Kaydet()
        {
            DegisiklikYapildi = false;
        }

        private void dosyaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Değişiklik yapıldıysa if e giriyor
            if (changesMade)
            {
                DialogResult result = MessageBox.Show("Kaydedilmemiş değişiklikler var. Yine de devam etmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // Kullanıcı evet derse açma işlemini gerçekleştir
                if (result == DialogResult.Yes)
                {
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.Filter = "Metin Dosyaları (*.txt)|*.txt|Tüm Dosyalar (*.*)|*.*";
                        openFileDialog.FilterIndex = 1;

                        // Seçilen dosyanın içeriğini metin kutusuna yükle
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {

                            string dosyaYolu = openFileDialog.FileName;
                            string dosyaIcerigi = File.ReadAllText(dosyaYolu);
                            richTextBox1.Text = dosyaIcerigi;

                            // Değişikliklerin kaydedildiğini işaretle
                            changesMade = false;
                        }
                    }
                }
            }
            //Değişiklik yapılmadıysa devam ediliyor
            else
            {
                // Kaydedilmemiş değişiklik yoksa direkt olarak dosya açma işlemini gerçekleştir
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    // Sadece metin dosyalarını seçilebilir yap
                    openFileDialog.Filter = "Metin Dosyaları (*.txt)|*.txt|Tüm Dosyalar (*.*)|*.*";
                    openFileDialog.FilterIndex = 1;

                    // Seçilen dosyanın içeriğini metin kutusuna yükle
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Seçilen dosyanın içeriğini metin kutusuna yükle
                        string dosyaYolu = openFileDialog.FileName;
                        string dosyaIcerigi = File.ReadAllText(dosyaYolu);
                        richTextBox1.Text = dosyaIcerigi;
                    }
                }
            }


        }

        private void yazıFontuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog renkDialog = new ColorDialog();
            renkDialog.AllowFullOpen = false; // Kullanıcının renk kodunu elle girmesine izin verme
            renkDialog.AnyColor = true; // Kullanıcıya tüm renkleri göster
            renkDialog.SolidColorOnly = true; // Sadece tek renk seçimine izin ver
            renkDialog.CustomColors = new int[] { 0xFF0000, 0x00FF00, 0x0000FF }; // Önceden tanımlanmış bazı renkler

            // Seçilen rengi al ve zemin rengini ayarla
            if (renkDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.BackColor = renkDialog.Color;
            }

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            DegisiklikYapildi = true;
        }

        public void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Metin Belgesi|*.txt|C++ Dosyası|*.cpp|C# Dosyası|*.cs|C Dosyası|*.c";

            // Eğer kullanıcı dosya kaydetmeyi seçtiyse (DialogResult.OK sonucu döndüyse), Seçilen dosyanın yolunu alıp, richTextBox1 kontrolündeki metni bu dosyaya yazılıyor
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
                dosyaKaydedildi = true;
                MessageBox.Show("Değişiklikler kaydedildi.");
            }

            Kaydet();

        }

        private void yazıÇeşitiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.FontMustExist = true; // Kullanıcının bilgisayarından olmayan bir font seçmesini engelle

            // Seçilen fontu al ve yazı çeşitlerini ayarla
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                // Seçilen fontu al ve yazı çeşitlerini ayarla
                richTextBox1.SelectionFont = fontDialog.Font;
            }

        }

        private void kaydetToolStripButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Metin Belgesi|*.txt|C++ Dosyası|*.cpp|C# Dosyası|*.cs|C Dosyası|*.c";


            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
                dosyaKaydedildi = true;
                MessageBox.Show("Değişiklikler kaydedildi.");
            }
            Kaydet();


        }

        private void yazdırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PrintDialog printDialog = new PrintDialog())
            {
                printDialog.Document = printDocument;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    // Kullanıcı yazdırmayı onayladığında, belgeyi yazdır
                    printDocument.Print();
                }
            }
        }
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            int charactersOnPage = 0;
            int linesPerPage = 0;
            int totalLines = 0;
            int startIndex = 0;
            int yPos = 0;
            string text = richTextBox1.Text;
            Font font = richTextBox1.Font;
            Brush brush = Brushes.Black;

            e.Graphics.MeasureString(text, font, e.MarginBounds.Size, StringFormat.GenericTypographic, out charactersOnPage, out linesPerPage);

            totalLines = text.Split('\n').Length;

            // Yazdırma işlemi yapılıyor
            while (totalLines > 0 && charactersOnPage > 0)
            {
                yPos = e.MarginBounds.Top + (linesPerPage - totalLines) * font.Height;

                e.Graphics.DrawString(text.Substring(startIndex), font, brush, e.MarginBounds.Left, yPos, StringFormat.GenericTypographic);

                totalLines -= linesPerPage;

                startIndex += linesPerPage;

                // Sayfa sonu kontrolü
                if (totalLines > 0)
                    e.HasMorePages = true;
            }
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Eğer değişiklik yapıldıysa uyarı veriliyor
            if (changesMade)
            {
                DialogResult result = MessageBox.Show("Kaydedilmemiş değişiklikler var. Yine de devam etmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // Kullanıcı evet derse açma işlemini gerçekleştir
                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            else
            {
                Application.Exit();
            }

        }

        private void geriAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void yineleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void kesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void kopyalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void yapıştırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void tümünüSeçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void yazıRengiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                // Renk seçme iletişim kutusunu göster
                ColorDialog renkDialog = new ColorDialog();
                renkDialog.AllowFullOpen = false; // Kullanıcının renk kodunu elle girmesine izin verme
                renkDialog.AnyColor = true; // Kullanıcıya tüm renkleri göster
                renkDialog.SolidColorOnly = true; // Sadece tek renk seçimine izin ver
                renkDialog.CustomColors = new int[] { 0xFF0000, 0x00FF00, 0x0000FF }; // Önceden tanımlanmış bazı renkler

                if (renkDialog.ShowDialog() == DialogResult.OK)
                {
                    // Seçilen rengi al ve yazı rengini ayarla
                    richTextBox1.ForeColor = renkDialog.Color;
                }
            }
        }

        private void dışarıdanAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Yazı Tipi Dosyaları|*.ttf;*.otf|Tüm Dosyalar|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Seçilen dosyadan yazı tipini yükle
                try
                {
                    PrivateFontCollection privateFonts = new PrivateFontCollection();
                    privateFonts.AddFontFile(openFileDialog.FileName);

                    // İlk yazı tipini al (kullanıcı birden fazla yazı tipi yükleyebilir)
                    Font yeniFont = new Font(privateFonts.Families[0], 12);

                    // Seçili metne yeni yazı tipini uygula
                    richTextBox1.SelectionFont = yeniFont;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Yazı tipi yüklenirken bir hata oluştu: " + ex.Message);
                }
            }
        }

        private void yeniToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void açToolStripButton_Click(object sender, EventArgs e)
        {
            if (changesMade)
            {
                DialogResult result = MessageBox.Show("Kaydedilmemiş değişiklikler var. Yine de devam etmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // Kullanıcı evet derse açma işlemini gerçekleştir
                if (result == DialogResult.Yes)
                {
                    // Açma işlemi için dosya seçme iletişim kutusunu göster
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        // Sadece metin dosyalarını seçilebilir yap
                        openFileDialog.Filter = "Metin Dosyaları (*.txt)|*.txt|Tüm Dosyalar (*.*)|*.*";
                        openFileDialog.FilterIndex = 1;

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            // Seçilen dosyanın içeriğini metin kutusuna yükle
                            string dosyaYolu = openFileDialog.FileName;
                            string dosyaIcerigi = File.ReadAllText(dosyaYolu);
                            richTextBox1.Text = dosyaIcerigi;

                            // Değişikliklerin kaydedildiğini işaretle
                            changesMade = false;
                        }
                    }
                }
            }
            else
            {
                // Kaydedilmemiş değişiklik yoksa direkt olarak dosya açma işlemini gerçekleştir
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    // Sadece metin dosyalarını seçilebilir yap
                    openFileDialog.Filter = "Metin Dosyaları (*.txt)|*.txt|Tüm Dosyalar (*.*)|*.*";
                    openFileDialog.FilterIndex = 1;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Seçilen dosyanın içeriğini metin kutusuna yükle
                        string dosyaYolu = openFileDialog.FileName;
                        string dosyaIcerigi = File.ReadAllText(dosyaYolu);
                        richTextBox1.Text = dosyaIcerigi;
                    }
                }
            }
        }

        private void yazdırToolStripButton_Click(object sender, EventArgs e)
        {
            using (PrintDialog printDialog = new PrintDialog())
            {
                printDialog.Document = printDocument;

                // Kullanıcı yazdırmayı onaylarsa belge yazılıyor
                if (printDialog.ShowDialog() == DialogResult.OK)
                {

                    printDocument.Print();
                }
            }
        }

        private void kesToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void kopyalaToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void yapıştırToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }


        private void SearchWord(string word)
        {
            int startIndex = richTextBox1.SelectionStart + richTextBox1.SelectionLength;

            int wordStartIndex = richTextBox1.Find(word, startIndex, RichTextBoxFinds.None);

            // Eğer kelime bulunduysa gösteriliyor
            if (wordStartIndex != -1)
            {
                richTextBox1.Select(wordStartIndex, word.Length);
                richTextBox1.Focus();
            }
            else
            {
                MessageBox.Show("Kelime bulunamadı!");
            }
        }

        private void araToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string aranacakKelime = Interaction.InputBox("Aranacak kelimeyi giriniz:", "Kelime Arama");

            // Aranacak kelimeyi ara
            SearchWord(aranacakKelime);
        }

        private void farklıKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Metin Belgesi|*.txt|C++ Dosyası|*.cpp|C# Dosyası|*.cs|C Dosyası|*.c";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
                dosyaKaydedildi = true;
                MessageBox.Show("Değişiklikler kaydedildi.");

            }
            Kaydet();

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void ileriAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void kesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void kopyalaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void yapıştırToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "";
        }

        private void tümünüSeçToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}

/****************************************************************************
**					                SAKARYA ÜNÝVERSÝTESÝ
**				          BÝLGÝSAYAR VE BÝLÝÞÝM BÝLÝMLERÝ FAKÜLTESÝ
**				                BÝLGÝSAYAR MÜHENDÝSLÝÐÝ BÖLÜMÜ
**				               NESNEYE DAYALI PROGRAMLAMA DERSÝ
**					               2023-2024 BAHAR DÖNEMÝ
**	
**				ÖDEV NUMARASI..........: 1
**				ÖÐRENCÝ ADI............: Tarýk Toplu
**				ÖÐRENCÝ NUMARASI.......: G231210010
**              DERSÝN ALINDIÐI GRUP...: A (ÝÖ)
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
            // Windows Not Defteri'nin varsayýlan fontunu ve boyutunu kullanarak
            Font defaultFont = new Font("Lucida Console,Regular", 10);

            // RichTextBox'in varsayýlan fontunu ayarla
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

        private void cDosyasýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Eðer deðiþiklik yapýldýysa uyarý veriliyor

            if (DegisiklikYapildi)
            {
                DialogResult result = MessageBox.Show("Dosyada kaydedilmemiþ deðiþiklikler var. Deðiþiklikleri kaydetmek istiyor musunuz?", "Uyarý", MessageBoxButtons.YesNoCancel);
                //Evet derse kayýt ediliyor
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

        private void cDosyasýToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Eðer deðiþiklik yapýldýysa uyarý veriliyor

            if (DegisiklikYapildi)
            {
                DialogResult result = MessageBox.Show("Dosyada kaydedilmemiþ deðiþiklikler var. Deðiþiklikleri kaydetmek istiyor musunuz?", "Uyarý", MessageBoxButtons.YesNoCancel);
                //Evet derse kayýt ediliyor
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
            //Eðer deðiþiklik yapýldýysa uyarý veriliyor
            if (DegisiklikYapildi)
            {
                DialogResult result = MessageBox.Show("Dosyada kaydedilmemiþ deðiþiklikler var. Deðiþiklikleri kaydetmek istiyor musunuz?", "Uyarý", MessageBoxButtons.YesNoCancel);

                //Evet derse kayýt ediliyor
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
            //Eðer deðiþiklik yapýldýysa uyarý veriliyor
            if (DegisiklikYapildi)
            {
                DialogResult result = MessageBox.Show("Dosyada kaydedilmemiþ deðiþiklikler var. Deðiþiklikleri kaydetmek istiyor musunuz?", "Uyarý", MessageBoxButtons.YesNoCancel);

                //Evet derse kayýt ediliyor
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
            saveFileDialog.Filter = dosyaUzantisi.ToUpper() + " Dosyalarý|*." + dosyaUzantisi;


            //Dosya þablonlarý için dosya oluþturuluyor
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string dosyaYolu = saveFileDialog.FileName;
                File.Create(dosyaYolu).Close(); // Dosyayý oluþtur ve kapat
                MessageBox.Show("Yeni " + dosyaUzantisi.ToUpper() + " dosyasý oluþturuldu: " + dosyaYolu);

                // Dosyayý oku ve içeriðini mevcut TextBox'a ekle
                string icerik = "";
                // Dosya uzantýsý cpp ise hello world þablonu yazýlýyor
                if (dosyaUzantisi == "cpp")
                {
                    icerik = "// C++ Hello World\n#include <iostream>\n\nint main() {\n    std::cout << \"Hello, World!\";\n    return 0;\n}";
                }

                // Dosya uzantýsý cs ise ise hello world þablonu yazýlýyor
                else if (dosyaUzantisi == "cs")
                {
                    icerik = "// C# Hello World\nusing System;\n\nclass Program\n{\n    static void Main(string[] args)\n    {\n        Console.WriteLine(\"Hello, World!\");\n    }\n}";
                }

                // Dosya uzantýsý c ise ise hello world þablonu yazýlýyor
                else if (dosyaUzantisi == "c")
                {
                    icerik = "// C Hello World\n#include <stdio.h>\n\nint main() {\n    printf(\"Hello, World!\");\n    return 0;\n}";
                }

                // Dosya uzantýsý txt ise ise hello world þablonu yazýlýyor
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
            //Deðiþiklik yapýldýysa if e giriyor
            if (changesMade)
            {
                DialogResult result = MessageBox.Show("Kaydedilmemiþ deðiþiklikler var. Yine de devam etmek istiyor musunuz?", "Uyarý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // Kullanýcý evet derse açma iþlemini gerçekleþtir
                if (result == DialogResult.Yes)
                {
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.Filter = "Metin Dosyalarý (*.txt)|*.txt|Tüm Dosyalar (*.*)|*.*";
                        openFileDialog.FilterIndex = 1;

                        // Seçilen dosyanýn içeriðini metin kutusuna yükle
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {

                            string dosyaYolu = openFileDialog.FileName;
                            string dosyaIcerigi = File.ReadAllText(dosyaYolu);
                            richTextBox1.Text = dosyaIcerigi;

                            // Deðiþikliklerin kaydedildiðini iþaretle
                            changesMade = false;
                        }
                    }
                }
            }
            //Deðiþiklik yapýlmadýysa devam ediliyor
            else
            {
                // Kaydedilmemiþ deðiþiklik yoksa direkt olarak dosya açma iþlemini gerçekleþtir
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    // Sadece metin dosyalarýný seçilebilir yap
                    openFileDialog.Filter = "Metin Dosyalarý (*.txt)|*.txt|Tüm Dosyalar (*.*)|*.*";
                    openFileDialog.FilterIndex = 1;

                    // Seçilen dosyanýn içeriðini metin kutusuna yükle
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Seçilen dosyanýn içeriðini metin kutusuna yükle
                        string dosyaYolu = openFileDialog.FileName;
                        string dosyaIcerigi = File.ReadAllText(dosyaYolu);
                        richTextBox1.Text = dosyaIcerigi;
                    }
                }
            }


        }

        private void yazýFontuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog renkDialog = new ColorDialog();
            renkDialog.AllowFullOpen = false; // Kullanýcýnýn renk kodunu elle girmesine izin verme
            renkDialog.AnyColor = true; // Kullanýcýya tüm renkleri göster
            renkDialog.SolidColorOnly = true; // Sadece tek renk seçimine izin ver
            renkDialog.CustomColors = new int[] { 0xFF0000, 0x00FF00, 0x0000FF }; // Önceden tanýmlanmýþ bazý renkler

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
            saveFileDialog1.Filter = "Metin Belgesi|*.txt|C++ Dosyasý|*.cpp|C# Dosyasý|*.cs|C Dosyasý|*.c";

            // Eðer kullanýcý dosya kaydetmeyi seçtiyse (DialogResult.OK sonucu döndüyse), Seçilen dosyanýn yolunu alýp, richTextBox1 kontrolündeki metni bu dosyaya yazýlýyor
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
                dosyaKaydedildi = true;
                MessageBox.Show("Deðiþiklikler kaydedildi.");
            }

            Kaydet();

        }

        private void yazýÇeþitiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.FontMustExist = true; // Kullanýcýnýn bilgisayarýndan olmayan bir font seçmesini engelle

            // Seçilen fontu al ve yazý çeþitlerini ayarla
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                // Seçilen fontu al ve yazý çeþitlerini ayarla
                richTextBox1.SelectionFont = fontDialog.Font;
            }

        }

        private void kaydetToolStripButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Metin Belgesi|*.txt|C++ Dosyasý|*.cpp|C# Dosyasý|*.cs|C Dosyasý|*.c";


            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
                dosyaKaydedildi = true;
                MessageBox.Show("Deðiþiklikler kaydedildi.");
            }
            Kaydet();


        }

        private void yazdýrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PrintDialog printDialog = new PrintDialog())
            {
                printDialog.Document = printDocument;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    // Kullanýcý yazdýrmayý onayladýðýnda, belgeyi yazdýr
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

            // Yazdýrma iþlemi yapýlýyor
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

        private void çýkýþToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Eðer deðiþiklik yapýldýysa uyarý veriliyor
            if (changesMade)
            {
                DialogResult result = MessageBox.Show("Kaydedilmemiþ deðiþiklikler var. Yine de devam etmek istiyor musunuz?", "Uyarý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // Kullanýcý evet derse açma iþlemini gerçekleþtir
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

        private void yapýþtýrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void tümünüSeçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void yazýRengiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                // Renk seçme iletiþim kutusunu göster
                ColorDialog renkDialog = new ColorDialog();
                renkDialog.AllowFullOpen = false; // Kullanýcýnýn renk kodunu elle girmesine izin verme
                renkDialog.AnyColor = true; // Kullanýcýya tüm renkleri göster
                renkDialog.SolidColorOnly = true; // Sadece tek renk seçimine izin ver
                renkDialog.CustomColors = new int[] { 0xFF0000, 0x00FF00, 0x0000FF }; // Önceden tanýmlanmýþ bazý renkler

                if (renkDialog.ShowDialog() == DialogResult.OK)
                {
                    // Seçilen rengi al ve yazý rengini ayarla
                    richTextBox1.ForeColor = renkDialog.Color;
                }
            }
        }

        private void dýþarýdanAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Yazý Tipi Dosyalarý|*.ttf;*.otf|Tüm Dosyalar|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Seçilen dosyadan yazý tipini yükle
                try
                {
                    PrivateFontCollection privateFonts = new PrivateFontCollection();
                    privateFonts.AddFontFile(openFileDialog.FileName);

                    // Ýlk yazý tipini al (kullanýcý birden fazla yazý tipi yükleyebilir)
                    Font yeniFont = new Font(privateFonts.Families[0], 12);

                    // Seçili metne yeni yazý tipini uygula
                    richTextBox1.SelectionFont = yeniFont;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Yazý tipi yüklenirken bir hata oluþtu: " + ex.Message);
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
                DialogResult result = MessageBox.Show("Kaydedilmemiþ deðiþiklikler var. Yine de devam etmek istiyor musunuz?", "Uyarý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // Kullanýcý evet derse açma iþlemini gerçekleþtir
                if (result == DialogResult.Yes)
                {
                    // Açma iþlemi için dosya seçme iletiþim kutusunu göster
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        // Sadece metin dosyalarýný seçilebilir yap
                        openFileDialog.Filter = "Metin Dosyalarý (*.txt)|*.txt|Tüm Dosyalar (*.*)|*.*";
                        openFileDialog.FilterIndex = 1;

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            // Seçilen dosyanýn içeriðini metin kutusuna yükle
                            string dosyaYolu = openFileDialog.FileName;
                            string dosyaIcerigi = File.ReadAllText(dosyaYolu);
                            richTextBox1.Text = dosyaIcerigi;

                            // Deðiþikliklerin kaydedildiðini iþaretle
                            changesMade = false;
                        }
                    }
                }
            }
            else
            {
                // Kaydedilmemiþ deðiþiklik yoksa direkt olarak dosya açma iþlemini gerçekleþtir
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    // Sadece metin dosyalarýný seçilebilir yap
                    openFileDialog.Filter = "Metin Dosyalarý (*.txt)|*.txt|Tüm Dosyalar (*.*)|*.*";
                    openFileDialog.FilterIndex = 1;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Seçilen dosyanýn içeriðini metin kutusuna yükle
                        string dosyaYolu = openFileDialog.FileName;
                        string dosyaIcerigi = File.ReadAllText(dosyaYolu);
                        richTextBox1.Text = dosyaIcerigi;
                    }
                }
            }
        }

        private void yazdýrToolStripButton_Click(object sender, EventArgs e)
        {
            using (PrintDialog printDialog = new PrintDialog())
            {
                printDialog.Document = printDocument;

                // Kullanýcý yazdýrmayý onaylarsa belge yazýlýyor
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

        private void yapýþtýrToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }


        private void SearchWord(string word)
        {
            int startIndex = richTextBox1.SelectionStart + richTextBox1.SelectionLength;

            int wordStartIndex = richTextBox1.Find(word, startIndex, RichTextBoxFinds.None);

            // Eðer kelime bulunduysa gösteriliyor
            if (wordStartIndex != -1)
            {
                richTextBox1.Select(wordStartIndex, word.Length);
                richTextBox1.Focus();
            }
            else
            {
                MessageBox.Show("Kelime bulunamadý!");
            }
        }

        private void araToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string aranacakKelime = Interaction.InputBox("Aranacak kelimeyi giriniz:", "Kelime Arama");

            // Aranacak kelimeyi ara
            SearchWord(aranacakKelime);
        }

        private void farklýKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Metin Belgesi|*.txt|C++ Dosyasý|*.cpp|C# Dosyasý|*.cs|C Dosyasý|*.c";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
                dosyaKaydedildi = true;
                MessageBox.Show("Deðiþiklikler kaydedildi.");

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

        private void yapýþtýrToolStripMenuItem1_Click(object sender, EventArgs e)
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

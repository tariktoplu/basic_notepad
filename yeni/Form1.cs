/****************************************************************************
**					                SAKARYA �N�VERS�TES�
**				          B�LG�SAYAR VE B�L���M B�L�MLER� FAK�LTES�
**				                B�LG�SAYAR M�HEND�SL��� B�L�M�
**				               NESNEYE DAYALI PROGRAMLAMA DERS�
**					               2023-2024 BAHAR D�NEM�
**	
**				�DEV NUMARASI..........: 1
**				��RENC� ADI............: Tar�k Toplu
**				��RENC� NUMARASI.......: G231210010
**              DERS�N ALINDI�I GRUP...: A (��)
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
            // Windows Not Defteri'nin varsay�lan fontunu ve boyutunu kullanarak
            Font defaultFont = new Font("Lucida Console,Regular", 10);

            // RichTextBox'in varsay�lan fontunu ayarla
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

        private void cDosyas�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //E�er de�i�iklik yap�ld�ysa uyar� veriliyor

            if (DegisiklikYapildi)
            {
                DialogResult result = MessageBox.Show("Dosyada kaydedilmemi� de�i�iklikler var. De�i�iklikleri kaydetmek istiyor musunuz?", "Uyar�", MessageBoxButtons.YesNoCancel);
                //Evet derse kay�t ediliyor
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

        private void cDosyas�ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //E�er de�i�iklik yap�ld�ysa uyar� veriliyor

            if (DegisiklikYapildi)
            {
                DialogResult result = MessageBox.Show("Dosyada kaydedilmemi� de�i�iklikler var. De�i�iklikleri kaydetmek istiyor musunuz?", "Uyar�", MessageBoxButtons.YesNoCancel);
                //Evet derse kay�t ediliyor
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
            //E�er de�i�iklik yap�ld�ysa uyar� veriliyor
            if (DegisiklikYapildi)
            {
                DialogResult result = MessageBox.Show("Dosyada kaydedilmemi� de�i�iklikler var. De�i�iklikleri kaydetmek istiyor musunuz?", "Uyar�", MessageBoxButtons.YesNoCancel);

                //Evet derse kay�t ediliyor
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
            //E�er de�i�iklik yap�ld�ysa uyar� veriliyor
            if (DegisiklikYapildi)
            {
                DialogResult result = MessageBox.Show("Dosyada kaydedilmemi� de�i�iklikler var. De�i�iklikleri kaydetmek istiyor musunuz?", "Uyar�", MessageBoxButtons.YesNoCancel);

                //Evet derse kay�t ediliyor
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
            saveFileDialog.Filter = dosyaUzantisi.ToUpper() + " Dosyalar�|*." + dosyaUzantisi;


            //Dosya �ablonlar� i�in dosya olu�turuluyor
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string dosyaYolu = saveFileDialog.FileName;
                File.Create(dosyaYolu).Close(); // Dosyay� olu�tur ve kapat
                MessageBox.Show("Yeni " + dosyaUzantisi.ToUpper() + " dosyas� olu�turuldu: " + dosyaYolu);

                // Dosyay� oku ve i�eri�ini mevcut TextBox'a ekle
                string icerik = "";
                // Dosya uzant�s� cpp ise hello world �ablonu yaz�l�yor
                if (dosyaUzantisi == "cpp")
                {
                    icerik = "// C++ Hello World\n#include <iostream>\n\nint main() {\n    std::cout << \"Hello, World!\";\n    return 0;\n}";
                }

                // Dosya uzant�s� cs ise ise hello world �ablonu yaz�l�yor
                else if (dosyaUzantisi == "cs")
                {
                    icerik = "// C# Hello World\nusing System;\n\nclass Program\n{\n    static void Main(string[] args)\n    {\n        Console.WriteLine(\"Hello, World!\");\n    }\n}";
                }

                // Dosya uzant�s� c ise ise hello world �ablonu yaz�l�yor
                else if (dosyaUzantisi == "c")
                {
                    icerik = "// C Hello World\n#include <stdio.h>\n\nint main() {\n    printf(\"Hello, World!\");\n    return 0;\n}";
                }

                // Dosya uzant�s� txt ise ise hello world �ablonu yaz�l�yor
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

        private void a�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //De�i�iklik yap�ld�ysa if e giriyor
            if (changesMade)
            {
                DialogResult result = MessageBox.Show("Kaydedilmemi� de�i�iklikler var. Yine de devam etmek istiyor musunuz?", "Uyar�", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // Kullan�c� evet derse a�ma i�lemini ger�ekle�tir
                if (result == DialogResult.Yes)
                {
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        openFileDialog.Filter = "Metin Dosyalar� (*.txt)|*.txt|T�m Dosyalar (*.*)|*.*";
                        openFileDialog.FilterIndex = 1;

                        // Se�ilen dosyan�n i�eri�ini metin kutusuna y�kle
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {

                            string dosyaYolu = openFileDialog.FileName;
                            string dosyaIcerigi = File.ReadAllText(dosyaYolu);
                            richTextBox1.Text = dosyaIcerigi;

                            // De�i�ikliklerin kaydedildi�ini i�aretle
                            changesMade = false;
                        }
                    }
                }
            }
            //De�i�iklik yap�lmad�ysa devam ediliyor
            else
            {
                // Kaydedilmemi� de�i�iklik yoksa direkt olarak dosya a�ma i�lemini ger�ekle�tir
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    // Sadece metin dosyalar�n� se�ilebilir yap
                    openFileDialog.Filter = "Metin Dosyalar� (*.txt)|*.txt|T�m Dosyalar (*.*)|*.*";
                    openFileDialog.FilterIndex = 1;

                    // Se�ilen dosyan�n i�eri�ini metin kutusuna y�kle
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Se�ilen dosyan�n i�eri�ini metin kutusuna y�kle
                        string dosyaYolu = openFileDialog.FileName;
                        string dosyaIcerigi = File.ReadAllText(dosyaYolu);
                        richTextBox1.Text = dosyaIcerigi;
                    }
                }
            }


        }

        private void yaz�FontuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog renkDialog = new ColorDialog();
            renkDialog.AllowFullOpen = false; // Kullan�c�n�n renk kodunu elle girmesine izin verme
            renkDialog.AnyColor = true; // Kullan�c�ya t�m renkleri g�ster
            renkDialog.SolidColorOnly = true; // Sadece tek renk se�imine izin ver
            renkDialog.CustomColors = new int[] { 0xFF0000, 0x00FF00, 0x0000FF }; // �nceden tan�mlanm�� baz� renkler

            // Se�ilen rengi al ve zemin rengini ayarla
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
            saveFileDialog1.Filter = "Metin Belgesi|*.txt|C++ Dosyas�|*.cpp|C# Dosyas�|*.cs|C Dosyas�|*.c";

            // E�er kullan�c� dosya kaydetmeyi se�tiyse (DialogResult.OK sonucu d�nd�yse), Se�ilen dosyan�n yolunu al�p, richTextBox1 kontrol�ndeki metni bu dosyaya yaz�l�yor
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
                dosyaKaydedildi = true;
                MessageBox.Show("De�i�iklikler kaydedildi.");
            }

            Kaydet();

        }

        private void yaz��e�itiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.FontMustExist = true; // Kullan�c�n�n bilgisayar�ndan olmayan bir font se�mesini engelle

            // Se�ilen fontu al ve yaz� �e�itlerini ayarla
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                // Se�ilen fontu al ve yaz� �e�itlerini ayarla
                richTextBox1.SelectionFont = fontDialog.Font;
            }

        }

        private void kaydetToolStripButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Metin Belgesi|*.txt|C++ Dosyas�|*.cpp|C# Dosyas�|*.cs|C Dosyas�|*.c";


            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
                dosyaKaydedildi = true;
                MessageBox.Show("De�i�iklikler kaydedildi.");
            }
            Kaydet();


        }

        private void yazd�rToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PrintDialog printDialog = new PrintDialog())
            {
                printDialog.Document = printDocument;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    // Kullan�c� yazd�rmay� onaylad���nda, belgeyi yazd�r
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

            // Yazd�rma i�lemi yap�l�yor
            while (totalLines > 0 && charactersOnPage > 0)
            {
                yPos = e.MarginBounds.Top + (linesPerPage - totalLines) * font.Height;

                e.Graphics.DrawString(text.Substring(startIndex), font, brush, e.MarginBounds.Left, yPos, StringFormat.GenericTypographic);

                totalLines -= linesPerPage;

                startIndex += linesPerPage;

                // Sayfa sonu kontrol�
                if (totalLines > 0)
                    e.HasMorePages = true;
            }
        }

        private void ��k��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //E�er de�i�iklik yap�ld�ysa uyar� veriliyor
            if (changesMade)
            {
                DialogResult result = MessageBox.Show("Kaydedilmemi� de�i�iklikler var. Yine de devam etmek istiyor musunuz?", "Uyar�", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // Kullan�c� evet derse a�ma i�lemini ger�ekle�tir
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

        private void yap��t�rToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void t�m�n�Se�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void yaz�RengiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                // Renk se�me ileti�im kutusunu g�ster
                ColorDialog renkDialog = new ColorDialog();
                renkDialog.AllowFullOpen = false; // Kullan�c�n�n renk kodunu elle girmesine izin verme
                renkDialog.AnyColor = true; // Kullan�c�ya t�m renkleri g�ster
                renkDialog.SolidColorOnly = true; // Sadece tek renk se�imine izin ver
                renkDialog.CustomColors = new int[] { 0xFF0000, 0x00FF00, 0x0000FF }; // �nceden tan�mlanm�� baz� renkler

                if (renkDialog.ShowDialog() == DialogResult.OK)
                {
                    // Se�ilen rengi al ve yaz� rengini ayarla
                    richTextBox1.ForeColor = renkDialog.Color;
                }
            }
        }

        private void d��ar�danAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Yaz� Tipi Dosyalar�|*.ttf;*.otf|T�m Dosyalar|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Se�ilen dosyadan yaz� tipini y�kle
                try
                {
                    PrivateFontCollection privateFonts = new PrivateFontCollection();
                    privateFonts.AddFontFile(openFileDialog.FileName);

                    // �lk yaz� tipini al (kullan�c� birden fazla yaz� tipi y�kleyebilir)
                    Font yeniFont = new Font(privateFonts.Families[0], 12);

                    // Se�ili metne yeni yaz� tipini uygula
                    richTextBox1.SelectionFont = yeniFont;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Yaz� tipi y�klenirken bir hata olu�tu: " + ex.Message);
                }
            }
        }

        private void yeniToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void a�ToolStripButton_Click(object sender, EventArgs e)
        {
            if (changesMade)
            {
                DialogResult result = MessageBox.Show("Kaydedilmemi� de�i�iklikler var. Yine de devam etmek istiyor musunuz?", "Uyar�", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // Kullan�c� evet derse a�ma i�lemini ger�ekle�tir
                if (result == DialogResult.Yes)
                {
                    // A�ma i�lemi i�in dosya se�me ileti�im kutusunu g�ster
                    using (OpenFileDialog openFileDialog = new OpenFileDialog())
                    {
                        // Sadece metin dosyalar�n� se�ilebilir yap
                        openFileDialog.Filter = "Metin Dosyalar� (*.txt)|*.txt|T�m Dosyalar (*.*)|*.*";
                        openFileDialog.FilterIndex = 1;

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            // Se�ilen dosyan�n i�eri�ini metin kutusuna y�kle
                            string dosyaYolu = openFileDialog.FileName;
                            string dosyaIcerigi = File.ReadAllText(dosyaYolu);
                            richTextBox1.Text = dosyaIcerigi;

                            // De�i�ikliklerin kaydedildi�ini i�aretle
                            changesMade = false;
                        }
                    }
                }
            }
            else
            {
                // Kaydedilmemi� de�i�iklik yoksa direkt olarak dosya a�ma i�lemini ger�ekle�tir
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    // Sadece metin dosyalar�n� se�ilebilir yap
                    openFileDialog.Filter = "Metin Dosyalar� (*.txt)|*.txt|T�m Dosyalar (*.*)|*.*";
                    openFileDialog.FilterIndex = 1;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Se�ilen dosyan�n i�eri�ini metin kutusuna y�kle
                        string dosyaYolu = openFileDialog.FileName;
                        string dosyaIcerigi = File.ReadAllText(dosyaYolu);
                        richTextBox1.Text = dosyaIcerigi;
                    }
                }
            }
        }

        private void yazd�rToolStripButton_Click(object sender, EventArgs e)
        {
            using (PrintDialog printDialog = new PrintDialog())
            {
                printDialog.Document = printDocument;

                // Kullan�c� yazd�rmay� onaylarsa belge yaz�l�yor
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

        private void yap��t�rToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }


        private void SearchWord(string word)
        {
            int startIndex = richTextBox1.SelectionStart + richTextBox1.SelectionLength;

            int wordStartIndex = richTextBox1.Find(word, startIndex, RichTextBoxFinds.None);

            // E�er kelime bulunduysa g�steriliyor
            if (wordStartIndex != -1)
            {
                richTextBox1.Select(wordStartIndex, word.Length);
                richTextBox1.Focus();
            }
            else
            {
                MessageBox.Show("Kelime bulunamad�!");
            }
        }

        private void araToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string aranacakKelime = Interaction.InputBox("Aranacak kelimeyi giriniz:", "Kelime Arama");

            // Aranacak kelimeyi ara
            SearchWord(aranacakKelime);
        }

        private void farkl�KaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Metin Belgesi|*.txt|C++ Dosyas�|*.cpp|C# Dosyas�|*.cs|C Dosyas�|*.c";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
                dosyaKaydedildi = true;
                MessageBox.Show("De�i�iklikler kaydedildi.");

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

        private void yap��t�rToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "";
        }

        private void t�m�n�Se�ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastColoredTextBoxNS;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace proyecto2_chatbot
{
    public partial class Form1 : Form
    {

        Style GreenStyle = new TextStyle(Brushes.Green, null, FontStyle.Regular);
        Style BlueStyle = new TextStyle(Brushes.Blue, null, FontStyle.Bold);
        Style BlueStyleRegular = new TextStyle(Brushes.Blue, null, FontStyle.Regular);
        Style OrangeStyle = new TextStyle(Brushes.Orange, null, FontStyle.Italic);
        Style RedStyle = new TextStyle(Brushes.Violet, null, FontStyle.Bold);
        Style SkyBlueStyle = new TextStyle(Brushes.DeepSkyBlue, null, FontStyle.Bold);
        Style blackStyle = new TextStyle(Brushes.Black, null, FontStyle.Regular);
        Style GrayStyle = new TextStyle(Brushes.Gray, null, FontStyle.Regular);

        string rut = " ";
        string nom = " ";
        RichTextBox ta;


        public Form1()
        {
            InitializeComponent();

            tabPrincipal.KeyDown += this.AreaLugar;
            tabPrincipal.MouseClick += this.AreaLugar;
            tabPrincipal.KeyPress += this.AreaLugar;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
           // AreaLugar(sender,e);

    }

        private void RichTextBox_TextChanged(object sender, EventArgs e)
        {
           // AreaLugar(sender,e);
        }

        private void abrir()
        {
            //cuadro abrir
            OpenFileDialog archivo = new OpenFileDialog();
            //inicia variable para leer el archivo
            System.IO.StreamReader leeArchivo = null;
            //Filtrar archivo
            archivo.Filter = "TXT (.txt)|*.txt";
            //visualizar ventana de archivos
            archivo.ShowDialog(this);

            try
            {
                //este codigo se utiliza para que se pueda pueda mostrar la informacion del archivo que queremos abrir 
                archivo.OpenFile();
                leeArchivo = System.IO.File.OpenText(archivo.FileName);
                crearVentana(archivo.SafeFileName, leeArchivo.ReadToEnd(), archivo.FileName);
               // txtEntrada.Text = leeArchivo.ReadToEnd();


            }
            catch (Exception)
            {

            }
        }

        private void AreaLugar(object sender, EventArgs e )
         {
            int x = tabPrincipal.SelectedIndex;
         


           // RichTextBox nuevo = (FastColoredTextBox)tabPrincipal.TabPages[x].Controls[0] ;
            

             int a=txtErrores.SelectionStart;

             int line, column;
             line = a-txtErrores.GetFirstCharIndexOfCurrentLine();
             column = txtErrores.GetLineFromCharIndex(a); 

             label1.Text = Convert.ToString(line+1 );
             label2.Text = Convert.ToString(column + 1);
         }

        private void crearVentana(string nombre, string texto, string ruta)
        {
            rut = ruta;
            nom = nombre;
            //   Console.WriteLine(texto);
            TabPage nuevo = new TabPage();
            nuevo.Name = nombre;
            nuevo.Text = nombre;
            FastColoredTextBox r = new FastColoredTextBox();
            r.WordWrap = true;
            r.ShowScrollBars = true;
            r.Height = 365;
            r.Width = 1203;
            r.TextChanged += fastColoredTextBox1_TextChanged;
            //r.AddStyle(GreenStyle);
            r.BorderStyle = System.Windows.Forms.BorderStyle.None;
            r.Name = ruta;
            r.Text = texto;
            nuevo.Focus();
            nuevo.Controls.Add(r);
            this.tabPrincipal.Controls.Add(nuevo);

            comboBox1.Items.Add(nombre);
            comboBox1.SelectedItem = nombre;
            tabPrincipal.SelectedTab = nuevo;

           

            tabPrincipal.KeyDown += this.AreaLugar;
            tabPrincipal.MouseClick += this.AreaLugar;
            tabPrincipal.KeyPress += this.AreaLugar;
            // nombreHoja.Text = ""; //descomentar
        }

        private void fastColoredTextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            //clear style of changed range
            e.ChangedRange.ClearStyle(GreenStyle);
            e.ChangedRange.ClearStyle(BlueStyle);
            e.ChangedRange.ClearStyle(BlueStyleRegular);
            e.ChangedRange.ClearStyle(OrangeStyle);
            e.ChangedRange.ClearStyle(RedStyle);
            e.ChangedRange.ClearStyle(SkyBlueStyle);
            e.ChangedRange.ClearStyle(blackStyle);
            e.ChangedRange.ClearStyle(GrayStyle);

            //apply styles
            //  e.ChangedRange.SetStyle(GreenStyle, @"#.*$", RegexOptions.Multiline); //comentario 
            // e.ChangedRange.SetStyle(GreenStyle, @"#\*(?:(?!\*/).)*\*#", RegexOptions.Singleline); //comentario multilinea
            // e.ChangedRange.SetStyle(OrangeStyle, "\\\".*\\\"", RegexOptions.Multiline); //



            //reservadas
          /*  e.ChangedRange.SetStyle(BlueStyle, analizador.grammar.clase, RegexOptions.None);
            e.ChangedRange.SetStyle(BlueStyleRegular, analizador.grammar.principal, RegexOptions.None);*/
            e.ChangedRange.SetStyle(BlueStyleRegular, @"String", RegexOptions.None);
            e.ChangedRange.SetStyle(BlueStyleRegular, @"Void", RegexOptions.None);
            e.ChangedRange.SetStyle(BlueStyleRegular, @"Default", RegexOptions.None);
            e.ChangedRange.SetStyle(BlueStyleRegular, @"Int", RegexOptions.None);
            e.ChangedRange.SetStyle(BlueStyleRegular, @"Double", RegexOptions.None);
            e.ChangedRange.SetStyle(BlueStyleRegular, @"True", RegexOptions.None);
            e.ChangedRange.SetStyle(BlueStyleRegular, @"False", RegexOptions.None);
            e.ChangedRange.SetStyle(BlueStyleRegular, @"If", RegexOptions.None);
            e.ChangedRange.SetStyle(BlueStyleRegular, @"Else", RegexOptions.None);
            e.ChangedRange.SetStyle(BlueStyleRegular, @"Switch", RegexOptions.None);
            e.ChangedRange.SetStyle(BlueStyleRegular, @"Case", RegexOptions.None);
            e.ChangedRange.SetStyle(BlueStyleRegular, @"Default", RegexOptions.None);
            e.ChangedRange.SetStyle(BlueStyleRegular, @"Break", RegexOptions.None);
            e.ChangedRange.SetStyle(BlueStyleRegular, @"Return", RegexOptions.None);
            e.ChangedRange.SetStyle(BlueStyleRegular, @"Char", RegexOptions.None);
            e.ChangedRange.SetStyle(BlueStyleRegular, @"Boolean", RegexOptions.None);
            e.ChangedRange.SetStyle(BlueStyleRegular, @"Import", RegexOptions.None);
            e.ChangedRange.SetStyle(BlueStyleRegular, @"For", RegexOptions.None);
            e.ChangedRange.SetStyle(BlueStyleRegular, @"Do", RegexOptions.None);
            e.ChangedRange.SetStyle(BlueStyleRegular, @"While", RegexOptions.None);
            e.ChangedRange.SetStyle(BlueStyleRegular, @"Print", RegexOptions.None);
            e.ChangedRange.SetStyle(BlueStyleRegular, @"CompareTo", RegexOptions.None);
            e.ChangedRange.SetStyle(BlueStyleRegular, @"GetUser()", RegexOptions.None);
            e.ChangedRange.SetStyle(GreenStyle, @"\+|-|\*|/|\^|%|&&|\|\||!=|<=|>=|<|>|==|!", RegexOptions.None);
            e.ChangedRange.SetStyle(blackStyle, @"[a-zA-Z_]+([0-9])*", RegexOptions.None); //id
            e.ChangedRange.SetStyle(RedStyle, @"[0-9]+(\.*[0-9]+)?", RegexOptions.Multiline); //numero
            e.ChangedRange.SetStyle(OrangeStyle, @"\""([a-zA-Z_]|[0-9]|)*\""", RegexOptions.Multiline); //cadena
            e.ChangedRange.SetStyle(GrayStyle, @"/\*([a-zA-Z_]|[0-9])*\*/", RegexOptions.Singleline); //comentario
            e.ChangedRange.SetStyle(GrayStyle, @"//([a-zA-Z_]|[0-9])*", RegexOptions.Singleline); //comentario
            e.ChangedRange.ClearFoldingMarkers();
            //set folding markers
            e.ChangedRange.SetFoldingMarkers("{", "}");

            //ejemplo
            //analizador.grammar nuevo = new analizador.grammar();
            // analizador.grammar.clase = nuevo.nohacenada();

        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrir();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            crearVentana("nuevo", "", "\\proyecto2_chatbot");
        }

        private void cerraPestañaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage pestañita = tabPrincipal.SelectedTab;
            tabPrincipal.TabPages.Remove(pestañita);
            comboBox1.Items.Remove(pestañita.Name);

            comboBox1.SelectedItem = tabPrincipal.SelectedTab.Name;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        public void guarda()
        {
            TabPage pestañita = tabPrincipal.SelectedTab;
           
            System.IO.StreamWriter myStream = null;
            

            try
            {
                myStream = System.IO.File.AppendText(rut);
                myStream.Write(((FastColoredTextBox)pestañita.Controls[0]).Text);
                myStream.Flush();
            }
            catch (Exception)
            {

            }
        }

        public void guardarComo()
        {
            TabPage pestañita = tabPrincipal.SelectedTab; 
            SaveFileDialog save = new SaveFileDialog();
            System.IO.StreamWriter myStream= null;
            save.CheckPathExists = true;
            save.Title = "Guardar como...";
            save.ShowDialog(this);

            try
            {
                myStream = System.IO.File.AppendText(save.FileName);
                myStream.Write(((FastColoredTextBox)pestañita.Controls[0]).Text);
                myStream.Flush();
            }
            catch (Exception)
            {

            }
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guardarComo();
        }

        private void reporteDeErroresToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ejecutarArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Analizar();
        }

        public void Analizar()
        {
            TabPage pestañita = tabPrincipal.SelectedTab;
            Analizador ej2 = new Analizador();
            txtErrores.Clear();

            if (ej2.esCadenaValida(((FastColoredTextBox)pestañita.Controls[0]).Text, new Gramatica()))
            {
                MessageBox.Show("CADENA VALIDA");
                /*    if (Analizador.padre.Root != null)
                    {
                      ej2.Recolectar_variables(Analizador.padre.Root).ToString();
                    }*/
                string cadenita2 = " ";
                for (int i = 0; i < Analizador.listaError.Count; i++)
                {
                    cadenita2 += Analizador.listaError[i] + "\r\n";

                }

                txtErrores.Text = cadenita2;
            }
            else
            {
                MessageBox.Show("CADENA INVALIDA");
                string cadenita2 = " ";
                for (int i = 0; i < Analizador.listaError.Count; i++)
                {
                    cadenita2 += Analizador.listaError[i] + "\r\n";

                }
                txtErrores.Text = cadenita2;
            }
        }

        private void ejecutarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Analizar();
        }

        private void reporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\Users\\Jacky Montenegro\\Desktop\\Rerrores.pdf");
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guarda();
        }
    }
}

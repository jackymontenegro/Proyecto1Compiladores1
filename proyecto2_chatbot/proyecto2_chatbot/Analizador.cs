using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Parsing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Irony.Ast;
using WINGRAPHVIZLib;

namespace proyecto2_chatbot
{
    class Analizador
    {
        int HOLA;        
        public static List<string> listaError = new List<string>();

        private static int contador;
        private static String grafo;
        public static ParseTree padre;

        public int pruebita (int a)
        {
            return 0;
        }
        public bool esCadenaValida(string cadenaEntrada, Grammar gramatica)
        {
            string actual = " ";

            LanguageData lenguaje = new LanguageData(gramatica);
            Parser p = new Parser(lenguaje);
            ParseTree arbol = p.Parse(cadenaEntrada);
            padre = arbol;
            generar_errores(arbol);


            if (arbol.Root == null)
            {
                MessageBox.Show("cagadales con parser");
                foreach (var mens in arbol.ParserMessages)
                {
                    if (mens.Message.Contains("Invalid character"))
                    {
                        string er;
                        er = "Error Léxico" + mens.Message + actual + (mens.Location.Line + 1) +" "+ (mens.Location.Column + 1);
                        listaError.Add(er);
                    }
                    else if (mens.Message.Contains("Syntax error"))
                    {
                        string er;
                    er="Error Sintáctico" + mens.Message + actual + (mens.Location.Line + 1) + " "+(mens.Location.Column + 1);
                        listaError.Add(er);
                    }
                   
                  
                }
            }
            else
            {
                //   Console.WriteLine(5 + 5);
                generarImagen(arbol.Root);

            }

            return arbol.Root != null;
        }

        public static void generar_errores(ParseTree arbol)
        {

            foreach (ParserMessage p in arbol.ParserMessages)
            {
                if (p.Message.Contains("Invalid"))
                {
                    listaError.Add(p.Message + " LEXICO " + p.Location.Line + " " + p.Location.Column);
                }
                else
                {
                    listaError.Add(p.Message + " SINTACTICO " + p.Location.Line + " " + p.Location.Column);
                }
            }

        }

        public static void generarImagen(ParseTreeNode raiz)
        {
            String grafoDOT = getDOT(raiz);
            WINGRAPHVIZLib.DOT dot = new WINGRAPHVIZLib.DOT();
            WINGRAPHVIZLib.BinaryImage img = dot.ToPNG(grafoDOT);
            // MessageBox.Show(grafoDOT);  
            //img.Save("C:\\Users\\ROBIN SALVATIERRA\\Dropbox\\OLC2\\OLC2_P1\\Proyecto1_200915428\\Proyecto1_200915428\\entradas\\robast.png");
            img.Save("robast.png");

        }


        //graficar arbol
        public static String getDOT(ParseTreeNode raiz)
        {

            grafo = "digraph G{" + "graph[bgcolor = black];" + "edge[color = white];";

            grafo += "nodo0[style=filled,label=\"" + escapar(raiz.ToString()) + "\",color = white,shape=egg];\n";
            contador = 1;
            recorrerAST("nodo0", raiz);
            grafo += "}";
            return grafo;
        }



        private static void recorrerAST(String padre, ParseTreeNode hijos)
        {

            foreach (ParseTreeNode hijo in hijos.ChildNodes)
            {

                String nombrehijo = "nodo" + contador.ToString();
                grafo += nombrehijo + "[style=filled,label=\"" + escapar(hijo.ToString()) + "\",color = white,shape=egg];\n";
                grafo += padre + "->" + nombrehijo + ";\n";
                contador++;
                recorrerAST(nombrehijo, hijo);
            }
        }

        private static String escapar(String cadena)
        {

            cadena = cadena.Replace("\\", "\\\\");
            cadena = cadena.Replace("\"", "\\\"");
            return cadena;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Parsing;
using Irony.Ast;

namespace proyecto2_chatbot
{
    class Gramatica : Grammar
    {
        public Gramatica() : base(caseSensitive: true)
        {
            //---------------------> Comentarios
            CommentTerminal COMENTARIO_SIMPLE = new CommentTerminal("comentario_simple", "//", "\n", "\r\n");
            CommentTerminal COMENTARIO_MULT = new CommentTerminal("comentario_mult", "/*", "*/");
            NonGrammarTerminals.Add(COMENTARIO_SIMPLE);
            NonGrammarTerminals.Add(COMENTARIO_MULT);

            //---------------------> Definir Palabras Reservadas

            MarkReservedWords("Int");
            MarkReservedWords("Double");
            MarkReservedWords("String");
            MarkReservedWords("Char");
            MarkReservedWords("Bool");
            MarkReservedWords("Void");

            MarkReservedWords("True");
            MarkReservedWords("False");

            MarkReservedWords("Import");

            MarkReservedWords("Return");

            MarkReservedWords("If");
            MarkReservedWords("Else");

            MarkReservedWords("Switch");
            MarkReservedWords("Case");
            MarkReservedWords("Break");
            MarkReservedWords("Default");

            MarkReservedWords("For");

            MarkReservedWords("Do");
            MarkReservedWords("While");

            MarkReservedWords("Print");

            MarkReservedWords("CompareTo");

            MarkReservedWords("GetUser()");


            //---------------------> (Opcional)Definir variables para palabras reservadas
            var entero = ToTerm("Int");
            var doubl = ToTerm("Double");
            var strin = ToTerm("String");
            var caracter = ToTerm("Char");
            var booleano = ToTerm("Bool");
            var voi = ToTerm("Void");

            var verdadero = ToTerm("True");
            var falso = ToTerm("False");

            var importacion = ToTerm("Import");


            var retornar = ToTerm("Return");

            var si = ToTerm("If");
            var sino = ToTerm("Else");

            var switc = ToTerm("Switch");
            var caso = ToTerm("Case");
            var brea = ToTerm("Break");
            var defaul = ToTerm("Default");

            var para = ToTerm("For");

            var hacer = ToTerm("Do");
            var mientras = ToTerm("While");

            var imprime = ToTerm("Print");

            var comparador = ToTerm("CompareTo");

            var nombreUsuario = ToTerm("GetUser()");

            //---------------------> (Opcional)Definir variables para signos y mas
            var coma = ToTerm(",");
            var pto = ToTerm(".");
            var pyc = ToTerm(";");
            var dospts = ToTerm(":");
            var apar = ToTerm("(");
            var cpar = ToTerm(")");
            var alla = ToTerm("{");
            var clla = ToTerm("}");
            var acor = ToTerm("[");
            var ccor = ToTerm("]");

            //------------------------> Operadores
            var mas = ToTerm("+");
            var menos = ToTerm("-");
            var multiplicacion = ToTerm("*");
            var division = ToTerm("/");
            var porcentaje = ToTerm("%");
            var potencia = ToTerm("^");

            var mayor = ToTerm(">");
            var menor = ToTerm("<");
            var menorigual = ToTerm("<=");
            var mayorigual = ToTerm(">=");
            var comparacion = ToTerm("==");
            var diferente = ToTerm("!=");

            var or = ToTerm("||");
            var and = ToTerm("&&");
            var xor = ToTerm("|&");
            var not = ToTerm("!");

            var suma = ToTerm("+=");
            var resta = ToTerm("-=");
            var asignar = ToTerm("=");

            var disminuir = ToTerm("--");
            var aumentar = ToTerm("++");


            //---------------------> No Terminales
            var INICIO = new NonTerminal("INICIO");
            var METODO = new NonTerminal("METODO");
            var SENTENCIAS = new NonTerminal("SENTENCIAS");
            var DECLARA = new NonTerminal("DECLARA");
            var ASIGNACIONVAR = new NonTerminal("ASIGNACIONVAR");
            var PARAMETROS = new NonTerminal("PARAMETROS");
            var PARA = new NonTerminal("PARA");
            var DECLARACIONES = new NonTerminal("DECLARACIONES");
            var IF = new NonTerminal("IF");
            var IFE = new NonTerminal("IFE");
            var VARIOS = new NonTerminal("VARIOS");
            var LLAMADA = new NonTerminal("LLAMADA");
            var VALORES = new NonTerminal("VALORES");
            var IMPRIMIR = new NonTerminal("IMPRIMIR");
            var WHILE = new NonTerminal("WHILE");
            var DOWHILE = new NonTerminal("DOWHILE");
            var TIPO = new NonTerminal("TIPO");
            var S = new NonTerminal("S");
            var EXPRE = new NonTerminal("EXPRE");
            var INCREMENTA = new NonTerminal("INCREMENTA");
            var DECREMENTA = new NonTerminal("DECREMENTA");
            var ASIGNACIONES = new NonTerminal("ASIGNACIONES");
            var IMPORTACIONES = new NonTerminal("IMPORTACIONES");
            var IMPORTACION = new NonTerminal("IMPORTACION");
            var VAR = new NonTerminal("VAR");
            var RETOR = new NonTerminal("RETOR");
            var CLASES = new NonTerminal("CLASES");
            var ARREGLOS = new NonTerminal("ARREGLOS");
            var SWITCH = new NonTerminal("SWITCH");
            var FOR = new NonTerminal("FOR");
            var CASOS = new NonTerminal("CASOS");
            var CASO = new NonTerminal("CASO");
            var COMPARTO = new NonTerminal("COMPARTO");

            //---------------------> Terminales
            NumberLiteral num = new NumberLiteral("num");
            IdentifierTerminal id = TerminalFactory.CreateCSharpIdentifier("id");
            var tstring = new StringLiteral("tstring", "\"", StringOptions.AllowsDoubledQuote);
            var tchar = new StringLiteral("tchar", "'", StringOptions.AllowsDoubledQuote);

            //----------------------------------------------PRODUCCIONES-----------------------------------------------------------

            S.Rule = IMPORTACIONES + CLASES;

            IMPORTACIONES.Rule = MakeStarRule(IMPORTACIONES, IMPORTACION);

            IMPORTACION.Rule = importacion + tstring + pyc;

            CLASES.Rule = MakeStarRule(CLASES, INICIO);

            INICIO.Rule = DECLARA + dospts + TIPO + METODO;

            /* --------------------------------------------------------------------------------------- *
             *                                   CREACION DE METODOS                                   *
             * --------------------------------------------------------------------------------------- */

            METODO.Rule = ASIGNACIONES + pyc
                            | apar + PARAMETROS + cpar + alla + VARIOS + clla;

            /* --------------------------------------------------------------------------------------- *
             *                                DECLARACION DE VARIABLES                                 *
             * --------------------------------------------------------------------------------------- */



            TIPO.Rule = entero | caracter | booleano | doubl | strin | voi;

            ARREGLOS.Rule = id + acor + EXPRE + ccor;


            DECLARACIONES.Rule = DECLARA + dospts + TIPO + ASIGNACIONES;

            ASIGNACIONES.Rule = asignar + EXPRE
                                | acor + EXPRE + ccor + asignar + alla + VALORES + clla
                                | acor + EXPRE + ccor
                                | acor + EXPRE + ccor + asignar + EXPRE
                                | Empty;

            DECLARA.Rule = DECLARA + coma + id
                                | id;


            ASIGNACIONVAR.Rule = id + asignar + EXPRE
                                | id + asignar + alla + VALORES + clla
                                | id + acor + EXPRE + ccor + asignar + EXPRE;

            PARAMETROS.Rule = PARAMETROS + coma + PARA
                                | PARA
                                | Empty;

            PARA.Rule = id + dospts + TIPO;

            /* --------------------------------------------------------------------------------------- *
             *                                      SENTENCIAS                                         *
             * --------------------------------------------------------------------------------------- */

            IMPRIMIR.Rule = imprime + apar + EXPRE + cpar + pyc;

            VARIOS.Rule = MakeStarRule(VARIOS, SENTENCIAS);

            SENTENCIAS.Rule = DECLARACIONES + pyc
                                | retornar + RETOR + pyc
                                | IF
                                | IFE
                                | WHILE
                                | DOWHILE
                                | IMPRIMIR
                                | INCREMENTA + pyc
                                | DECREMENTA + pyc
                                | LLAMADA + pyc
                                | ASIGNACIONVAR + pyc
                                | ARREGLOS
                                | brea + pyc
                                | SWITCH
                                | FOR;

            LLAMADA.Rule = id + apar + VALORES + cpar;

            RETOR.Rule = EXPRE
                        | Empty;

            VALORES.Rule = VALORES + coma + EXPRE
                                | EXPRE
                                | Empty;

            IF.Rule = si + apar + EXPRE + cpar + alla + VARIOS + clla;

            IFE.Rule = si + apar + EXPRE + cpar + alla + VARIOS + clla + sino + alla + VARIOS + clla;

            WHILE.Rule = mientras + apar + EXPRE + cpar + alla + VARIOS + clla;

            DOWHILE.Rule = hacer + alla + VARIOS + clla + mientras + apar + EXPRE + cpar;

            INCREMENTA.Rule = EXPRE + mas + mas;

            DECREMENTA.Rule = EXPRE + menos + menos;

            SWITCH.Rule = switc + apar + EXPRE + cpar + alla + CASOS + clla;

            CASOS.Rule = MakePlusRule(CASOS, CASO);

            CASO.Rule = caso + EXPRE + dospts + VARIOS + brea + pyc
                        | defaul + dospts + VARIOS;

            FOR.Rule = para + apar + DECLARACIONES + pyc + EXPRE + pyc + EXPRE + cpar + alla + VARIOS + clla;

            COMPARTO.Rule = id + pto + comparador + apar + EXPRE + cpar;

           

            /* --------------------------------------------------------------------------------------- *
             *                       OPERACIONES ARITMETICAS Y RELACIONALES                            *
             * --------------------------------------------------------------------------------------- */

            EXPRE.Rule = EXPRE + or + EXPRE
                    | EXPRE + and + EXPRE
                    | EXPRE + comparacion + EXPRE
                    | EXPRE + diferente + EXPRE
                    | EXPRE + mayor + EXPRE
                    | EXPRE + mayorigual + EXPRE
                    | EXPRE + menor + EXPRE
                    | EXPRE + menorigual + EXPRE
                    | EXPRE + mas + EXPRE
                    | EXPRE + menos + EXPRE
                    | EXPRE + multiplicacion + EXPRE
                    | EXPRE + division + EXPRE
                    | EXPRE + porcentaje + EXPRE
                    | apar + EXPRE + cpar
                    | num
                    | menos + num
                    | id
                    | verdadero
                    | falso
                    | tstring
                    | LLAMADA
                    | INCREMENTA
                    | DECREMENTA
                    | tchar
                    | ARREGLOS
                    | COMPARTO
                    | nombreUsuario;


            //---------------------> No Terminal Inicial
            this.Root = S;

            //---------------------> Definir Asociatividad
            RegisterOperators(1, Associativity.Left, or);                 //OR
            RegisterOperators(2, Associativity.Left, and);                 //AND
            RegisterOperators(3, Associativity.Left, comparacion, diferente);           //IGUAL, DIFERENTE
            RegisterOperators(4, Associativity.Left, mayor, menor, mayorigual, menorigual); //MAYORQUES, MENORQUES
            RegisterOperators(5, Associativity.Left, mas, menos);           //MAS, MENOS
            RegisterOperators(6, Associativity.Left, multiplicacion, division);        //POR, DIVIDIR
            RegisterOperators(2, Associativity.Left, porcentaje);                 //POTENCIA
            RegisterOperators(7, Associativity.Right, "!");                 //NOT


            //---------------------> Manejo de Errores
         /*   SENTENCIAS.ErrorRule = SyntaxError + clla;
            METODO.ErrorRule = SyntaxError + clla;*/
            //CASOS.ErrorRule = SyntaxError + CASO;*/

            //---------------------> Eliminacion de caracters, no terminales
            this.MarkPunctuation(apar, cpar, pyc, alla, clla, asignar, coma, dospts, acor, ccor,pto);
            // this.MarkPunctuation("print", "if", "else", "do", "while");
            // this.MarkTransient(SENTENCIA);
            //this.MarkTransient(CASO);
        }

    }
}
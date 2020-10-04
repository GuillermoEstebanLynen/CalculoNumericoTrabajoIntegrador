using System;
using System.Collections.Generic;
using System.Text;
using ComercioConsola;
using ComercioControlador;
using ComercioModelo;

namespace ConsoleTrabajoIntegrador.SubMenus
{
    public class SubMenuCategorias
    {
        public static void MenuCategorias()
        {
            Console.Clear();

            //Lista de Opciones
            List<string> opciones = new List<string>();
            opciones.Add("Mostrar todas las categorias");
            opciones.Add("Agregar Categoria");
            opciones.Add("Editar Categoria");
            opciones.Add("Eliminar Categoria");
            opciones.Add("Volver al menu Home");

            Formatos.DibujarMenu("Categorias", opciones);
            int opcionElegida = Validadores.ValidarOpcionMenu("Ingrese la opcion que desea elegir: ", opciones.Count);

            switch (opcionElegida)
            {
                case 1:
                    Show();
                    MenuCategorias();
                    break;
                case 2:
                    Add();
                    MenuCategorias();
                    break;
                case 3:
                    Edit();
                    MenuCategorias();
                    break;
                case 4:
                    Delete();
                    MenuCategorias();
                    break;
                case 5:
                    Menus.Home();
                    break;
            }

        }

        private static void Show()
        {
            Console.Clear();

            TablaCategorias(Comercio.categorias);

            Console.WriteLine();
            Validadores.EsperaTecla();
        }

        private static void Add()
        {
            try
            {
                string nombreElegido = Validadores.ValidarTexto("Escriba el nombre de la categoria que desea crear: ");
                bool resultado = CategoriaController.Add(nombreElegido);
                if (resultado)
                {
                    Formatos.SetTextSucess("Categoria Creada Satisfactoriamente!!!");
                    Validadores.EsperaTecla();
                }
                else
                {
                    Formatos.SetTextError("Categoria NO Creada por un error desconocido");
                    Validadores.EsperaTecla();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Formatos.SetTextError(string.Format("Se ha producido el siguiene error: {0}", e.Message));
                Validadores.EsperaTecla();
            }
        }

        private static void Edit()
        {
            Console.Clear();
            try
            {
                Console.Clear();

                TablaCategorias(Comercio.categorias);

                int indiceCategoriaElegida = Validadores.ValidarOpcionMenu("Elija la categoria que desea editar: ", Comercio.categorias.Count);
                string nombreAReemplezar = Validadores.ValidarTexto("Elija el nombre por el cual desea reemplazar: ");

                indiceCategoriaElegida -= 1;

                bool resultado = CategoriaController.Edit(indiceCategoriaElegida, nombreAReemplezar);

                if (resultado)
                {
                    Formatos.SetTextSucess("Categoria Editada Satisfactoriamente!!!");
                    Validadores.EsperaTecla();
                }
                else
                {
                    Formatos.SetTextError("Categoria NO Editada por un error desconocido");
                    Validadores.EsperaTecla();
                    Console.ReadKey();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Formatos.SetTextError(string.Format("Se ha producido el siguiene error: {0}", e.Message));
                Validadores.EsperaTecla();
            }
        }

        private static void Delete()
        {
            Console.Clear();
            try
            {
                Console.Clear();

                TablaCategorias(Comercio.categorias);

                int indiceCategoriaElegida = Validadores.ValidarOpcionMenu("Elija la categoria que desea eliminar: ", Comercio.categorias.Count);

                indiceCategoriaElegida -= 1;

                bool resultado = CategoriaController.Delete(indiceCategoriaElegida);

                if (resultado)
                {
                    Formatos.SetTextSucess("Categoria Eliminada Satisfactoriamente!!!");
                    Console.WriteLine("Aprete Cualquier tecla para volver al menu");
                    Console.ReadKey();
                }
                else
                {
                    Formatos.SetTextError("Categoria NO Eliminada por un error desconocido");
                    Validadores.EsperaTecla();
                    Console.ReadKey();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Formatos.SetTextError(string.Format("Se ha producido el siguiene error: {0}", e.Message));
                Validadores.EsperaTecla();
            }
        }

        public static void TablaCategorias(List<Categoria> categorias)
        {

            //Lista a dibujar
            List<string> categoriasToString = new List<string>();

            foreach (Categoria categoria in categorias)
            {
                categoriasToString.Add(categoria.ToString());
            }

            string encabezadoTabla = string.Format($"#   | {"Nombre",-20}");

            Formatos.DibujarMenu(encabezadoTabla, categoriasToString);
        }

    }
}

using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t----- Bienvenido -----");
            int op = 0;
            
            while (op != 6)
            {
                
                Console.WriteLine("\n¿Qué acción desea realizar?" +
                                  "\n 1. Agregar un nuevo paciente \n 2. Actualizar registro de paciente " +
                                  "\n 3. Eliminar un registro de paciente \n 4. Mostrar todos los pacientes " +
                                  "\n 5. Buscar paciente por su ID \n 6. Salir");
                Console.Write("Su opción: ");
                op = int.Parse(Console.ReadLine());
                
                switch (op)
                {

                    case 1:
                        ML.Result result = Add();
                        if (result.Correct)
                        {
                            Console.WriteLine("\n\t----- Paciente registrado correctamente -----");
                        }
                        else
                        {
                            Console.WriteLine("Error al registar al paciente");
                        }
                        break;

                    case 2:
                        result = Update();
                        if (result.Correct)
                        {
                            Console.WriteLine("\n\t----- Registro actualizado correctamente -----");
                        }
                        else
                        {
                            Console.WriteLine("Error al actualizar al paciente");
                        }
                        break;

                    case 3:
                        Console.Write("\nIngrese el ID del registro a eliminar: ");
                        int id = int.Parse(Console.ReadLine());
                        result = BL.Paciente.Delete(id);
                        if (result.Correct)
                        {
                            Console.WriteLine("\n\t----- Registro eliminado correctamente ------");
                        }
                        else
                        {
                            Console.WriteLine("\n\t ----- Error al eliminar el registro -----");
                        }
                        break;

                    case 4:
                        result = BL.Paciente.GetAll();
                        if (result.Correct)
                        {
                            Console.WriteLine("\t----- Pacientes -----");
                            foreach (ML.Paciente paciente in result.Objects.Cast<Paciente>())
                            {                                
                                Console.Write("Id: " + paciente.IdPaciente);
                                Console.Write("\nNombre: " + paciente.Nombre);
                                Console.Write("\nApellido Paterno: " + paciente.ApellidoPaterno);
                                Console.Write("\nApellido Materno: " + paciente.ApellidoMaterno);
                                Console.Write("\nFecha de Nacimiento: " + paciente.FechaNacimiento);
                                Console.Write("\nIdTipoSangre: " + paciente.TipoSangre.IdTipoSangre);
                                Console.Write("\nNombreTipoSangre: " + paciente.TipoSangre.Nombre);
                                Console.Write("\nSexo: " + paciente.Sexo);
                                Console.Write("\nFecha de Ingreso: " + paciente.FechaIngreso);
                                Console.Write("\nDiagnostico: " + paciente.Diagnostisco);
                                Console.WriteLine("\n--------------------");
                            }
                        }
                        break;

                    case 5:
                        Console.Write("\nIngrese el ID del paciente: ");
                        int idPaciente = int.Parse(Console.ReadLine());
                        result = BL.Paciente.GetById(idPaciente);
                        var item = (ML.Paciente)result.Object;
                        if (result.Correct)
                        {
                            Console.WriteLine("\n\t----- Paciente -----");
                                                       
                                Console.Write("Id: " + item.IdPaciente);
                                Console.Write("\nNombre: " + item.Nombre);
                                Console.Write("\nApellido Paterno: " + item.ApellidoPaterno);
                                Console.Write("\nApellido Materno: " + item.ApellidoMaterno);
                                Console.Write("\nFecha de Nacimiento: " + item.FechaNacimiento);
                                Console.Write("\nIdTipoSangre: " + item.TipoSangre.IdTipoSangre);
                                Console.Write("\nNombreTipoSangre: " + item.TipoSangre.Nombre);
                                Console.Write("\nSexo: " + item.Sexo);
                                Console.Write("\nFecha de Ingreso: " + item.FechaIngreso);
                                Console.Write("\nDiagnostico: " + item.Diagnostisco);
                                Console.WriteLine("\n--------------------");
                            
                        }
                        break;

                    default:
                        break;
                }
            }
            
        }

        static ML.Result Add()
        {
            ML.Paciente paciente = new ML.Paciente();
            Console.WriteLine("Ingrese los datos del paciente: ");
            Console.Write("Nombre: ");
            paciente.Nombre = Console.ReadLine();
            Console.Write("Apellido Paterno: ");
            paciente.ApellidoPaterno = Console.ReadLine();
            Console.Write("Apellido Materno: ");
            paciente.ApellidoMaterno = Console.ReadLine();
            Console.Write("Fecha de Nacimiento(DD-MM-AAAA): ");
            paciente.FechaNacimiento = Console.ReadLine();
            Console.Write("IdTipoSangre: ");
            paciente.TipoSangre = new ML.TipoSangre();
            paciente.TipoSangre.IdTipoSangre = int.Parse(Console.ReadLine());
            Console.Write("Sexo: ");
            paciente.Sexo = Console.ReadLine();
            Console.Write("Diagnostico: ");
            paciente.Diagnostisco = Console.ReadLine();

            ML.Result result = BL.Paciente.Add(paciente);
            return result;
        }//Add

        static ML.Result Update()
        {
            ML.Paciente paciente = new ML.Paciente();
            Console.Write("\nIngrese el ID del registro a actualizar: ");
            paciente.IdPaciente = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese los datos del paciente: ");
            Console.Write("Nombre: ");
            paciente.Nombre = Console.ReadLine();
            Console.Write("Apellido Paterno: ");
            paciente.ApellidoPaterno = Console.ReadLine();
            Console.Write("Apellido Materno: ");
            paciente.ApellidoMaterno = Console.ReadLine();
            Console.Write("Fecha de Nacimiento(DD-MM-AAAA): ");
            paciente.FechaNacimiento = Console.ReadLine();
            Console.Write("IdTipoSangre: ");
            paciente.TipoSangre = new ML.TipoSangre();
            paciente.TipoSangre.IdTipoSangre = int.Parse(Console.ReadLine());
            Console.Write("Sexo: ");
            paciente.Sexo = Console.ReadLine();
            Console.Write("Diagnostico: ");
            paciente.Diagnostisco = Console.ReadLine();

            ML.Result result = BL.Paciente.Update(paciente);
            return result;            
        }

    }
}

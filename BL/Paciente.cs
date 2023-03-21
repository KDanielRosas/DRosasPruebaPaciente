using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ML;
using System.Runtime.InteropServices;

namespace BL
{
    public class Paciente
    {
        public static ML.Result Add(ML.Paciente paciente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "PacienteAdd";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] parametros = new SqlParameter[7];

                        parametros[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        parametros[0].Value = paciente.Nombre;

                        parametros[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        parametros[1].Value = paciente.ApellidoPaterno;

                        parametros[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        parametros[2].Value = paciente.ApellidoMaterno;

                        parametros[3] = new SqlParameter("FechaNacimiento", SqlDbType.VarChar);
                        parametros[3].Value = paciente.FechaNacimiento;

                        parametros[4] = new SqlParameter("IdTipoSangre", SqlDbType.VarChar);
                        parametros[4].Value = paciente.TipoSangre.IdTipoSangre;

                        parametros[5] = new SqlParameter("Sexo", SqlDbType.Char);
                        parametros[5].Value = paciente.Sexo;

                        parametros[6] = new SqlParameter("Diagnostico", SqlDbType.VarChar);
                        parametros[6].Value = paciente.Diagnostisco;

                        cmd.Parameters.AddRange(parametros);
                        cmd.Connection.Open();

                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }

                    }//SQLCommand
                }//SQLConnection
            }//try
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Exception = ex;
                throw;
            }//catch                     
            return result;
        }//Add

        public static ML.Result Update(ML.Paciente paciente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "PacienteUpdate";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] parametros = new SqlParameter[8];

                        parametros[0] = new SqlParameter("IdPaciente", SqlDbType.Int);
                        parametros[0].Value = paciente.IdPaciente;

                        parametros[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        parametros[1].Value = paciente.Nombre;

                        parametros[2] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        parametros[2].Value = paciente.ApellidoPaterno;

                        parametros[3] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        parametros[3].Value = paciente.ApellidoMaterno;

                        parametros[4] = new SqlParameter("FechaNacimiento", SqlDbType.VarChar);
                        parametros[4].Value = paciente.FechaNacimiento;

                        parametros[5] = new SqlParameter("IdTipoSangre", SqlDbType.VarChar);
                        parametros[5].Value = paciente.TipoSangre.IdTipoSangre;

                        parametros[6] = new SqlParameter("Sexo", SqlDbType.Char);
                        parametros[6].Value = paciente.Sexo;

                        parametros[7] = new SqlParameter("Diagnostico", SqlDbType.VarChar);
                        parametros[7].Value = paciente.Diagnostisco;

                        cmd.Parameters.AddRange(parametros);
                        cmd.Connection.Open();

                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }

                    }//SQLCommand
                }//SQLConnection
            }//try
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Exception = ex;
                throw;
            }//catch                     
            return result;
        }//Add
        public static ML.Result Delete(int idPaciente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "PacienteDelete";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = context;

                        SqlParameter[] parametros = new SqlParameter[1];

                        parametros[0] = new SqlParameter("IdPaciente", SqlDbType.Int);
                        parametros[0].Value = idPaciente;

                        cmd.Parameters.AddRange(parametros);
                        cmd.Connection.Open();

                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }//try
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                throw;
            }//catch
            return result;
        }//Delete

        public static ML.Result GetAll()
        {
            ML.Result result = new Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "PacienteGetAll";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataTable dataTable = new DataTable();

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                        sqlDataAdapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (DataRow row in dataTable.Rows)
                            {
                                ML.Paciente paciente = new ML.Paciente();
                                paciente.IdPaciente = (int)row[0];
                                paciente.Nombre = (string)row[1];
                                paciente.ApellidoPaterno = (string)row[2];
                                paciente.ApellidoMaterno = (string)row[3];
                                paciente.FechaNacimiento = (string)row[4];
                                paciente.TipoSangre = new TipoSangre();
                                paciente.TipoSangre.IdTipoSangre = (byte)row[5];
                                paciente.TipoSangre.Nombre = (string)row[6];
                                paciente.Sexo = (string)row[7];
                                paciente.FechaIngreso = (DateTime)row[8];
                                paciente.Diagnostisco = (string)row[9];

                                result.Objects.Add(paciente);
                            }//foreach
                        }//if
                        result.Correct = true;
                    }//SQLCommand
                }//SQLConnection
            }//try
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Exception = ex;
                throw;
            }//catch
            return result;
        }//GetAll}

        public static ML.Result GetById(int idPaciente)
        {
            ML.Result result = new Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "PacienteGetById";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] parametros = new SqlParameter[1];

                        parametros[0] = new SqlParameter("IdPaciente", SqlDbType.Int);
                        parametros[0].Value = idPaciente;

                        cmd.Parameters.AddRange(parametros);
                        cmd.Connection.Open();

                        DataTable dataTable = new DataTable();

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                        sqlDataAdapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0)
                        {
                            result.Object = new ML.Paciente();
                            foreach (DataRow row in dataTable.Rows)
                            {
                                ML.Paciente paciente = new ML.Paciente();
                                paciente.IdPaciente = (int)row[0];
                                paciente.Nombre = (string)row[1];
                                paciente.ApellidoPaterno = (string)row[2];
                                paciente.ApellidoMaterno = (string)row[3];
                                paciente.FechaNacimiento = (string)row[4];
                                paciente.TipoSangre = new TipoSangre();
                                paciente.TipoSangre.IdTipoSangre = (byte)row[5];
                                paciente.TipoSangre.Nombre = (string)row[6];
                                paciente.Sexo = (string)row[7];
                                paciente.FechaIngreso = (DateTime)row[8];
                                paciente.Diagnostisco = (string)row[9];

                                result.Object = paciente;
                            }//foreach
                        }//if
                        result.Correct = true;
                    }//SQLCommand
                }//SQLConnection
            }//try
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Exception = ex;
                throw;
            }//catch
            return result;
        }//GetAll
    }//classPaciente
}//NS

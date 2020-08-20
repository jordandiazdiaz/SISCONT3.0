﻿using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DaoPlanContable
    {
        private Conexion conexion = new Conexion();
        SqlCommand sqlCommand = new SqlCommand();

        public string ShowAcount(string codigo)
        {
            DataTable dataTable = new DataTable();
            SqlDataReader sqlDataReader;
            sqlCommand.Connection = conexion.OpenConnection();
            sqlCommand.CommandText = "sp_show_name_cuenta";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@codigo", codigo);

            sqlCommand.ExecuteNonQuery();
            sqlDataReader = sqlCommand.ExecuteReader();
            dataTable.Load(sqlDataReader);
            sqlCommand.Parameters.Clear();

            conexion.CloseConnection();

            if (dataTable.Rows.Count > 0)
                return dataTable.Rows[0]["Cuenta"].ToString();
            else
                return null;
        }

        public DataTable ShowAcountFilter(string clasificacion)
        {
            DataTable dataTable = new DataTable();
            SqlDataReader sqlDataReader;

            sqlCommand.Connection = conexion.OpenConnection();
            sqlCommand.CommandText = "sp_show_plan_filter";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@clasificacion", clasificacion);

            sqlCommand.ExecuteNonQuery();
            sqlDataReader = sqlCommand.ExecuteReader();
            dataTable.Load(sqlDataReader);
            sqlCommand.Parameters.Clear();

            conexion.CloseConnection();

            return dataTable;
        }

        public DataTable All()
        {
            SqlDataReader sqlDataReader;
            DataTable dataTable = new DataTable();
            sqlCommand.Connection = conexion.OpenConnection();
            sqlCommand.CommandText = "sp_all_plan_contable";
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlDataReader = sqlCommand.ExecuteReader();
            dataTable.Load(sqlDataReader);
            conexion.CloseConnection();
            return dataTable;
        }

        //public DataTable Show(string usuario)
        //{
        //    SqlDataReader sqlDataReader;
        //    DataTable dataTable = new DataTable();

        //    sqlCommand.Connection = conexion.OpenConnection();
        //    sqlCommand.CommandText = "sp_show_user";
        //    sqlCommand.CommandType = CommandType.StoredProcedure;

        //    sqlCommand.Parameters.AddWithValue("@Usuario", usuario);

        //    sqlCommand.ExecuteNonQuery();
        //    sqlDataReader = sqlCommand.ExecuteReader();
        //    dataTable.Load(sqlDataReader);
        //    sqlCommand.Parameters.Clear();

        //    conexion.CloseConnection();
        //    return dataTable;
        //}

        public bool Insert(string usuario, string contrasenia, string nombre, string correo, string telefono, int rolId)
        {
            sqlCommand.Connection = conexion.OpenConnection();
            sqlCommand.CommandText = "sp_insert_user";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@Usuario", usuario);
            sqlCommand.Parameters.AddWithValue("@Contrasenia", contrasenia);
            sqlCommand.Parameters.AddWithValue("@Nombre", nombre);
            sqlCommand.Parameters.AddWithValue("@Correo", correo);
            sqlCommand.Parameters.AddWithValue("@Telefono", telefono);
            sqlCommand.Parameters.AddWithValue("@RolId", rolId);

            if (sqlCommand.ExecuteNonQuery() > 0)
            {
                sqlCommand.Parameters.Clear();
                conexion.CloseConnection();
                return true;
            }
            else
                return false;
        }

        public bool Update(int id, string usuario, string contrasenia, string nombre, string correo, string telefono, int rolId)
        {
            sqlCommand.Connection = conexion.OpenConnection();
            sqlCommand.CommandText = "sp_update_user";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@idUsuario", id);
            sqlCommand.Parameters.AddWithValue("@Usuario", usuario);
            sqlCommand.Parameters.AddWithValue("@Contrasenia", contrasenia);
            sqlCommand.Parameters.AddWithValue("@Nombre", nombre);
            sqlCommand.Parameters.AddWithValue("@Correo", correo);
            sqlCommand.Parameters.AddWithValue("@Telefono", telefono);
            sqlCommand.Parameters.AddWithValue("@RolId", rolId);

            if (sqlCommand.ExecuteNonQuery() > 0)
            {
                sqlCommand.Parameters.Clear();
                conexion.CloseConnection();
                return true;
            }
            else
                return false;
        }

        public bool Destroy(int id)
        {
            sqlCommand.Connection = conexion.OpenConnection();
            sqlCommand.CommandText = "sp_delete_user";
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@idUsuario", id);

            if (sqlCommand.ExecuteNonQuery() > 0)
            {
                sqlCommand.Parameters.Clear();
                conexion.CloseConnection();
                return true;
            }
            else
                return false;
        }

    }
}

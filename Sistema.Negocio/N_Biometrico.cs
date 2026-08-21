using System;
using System.Collections.Generic;
using System.Data;
using Sistema.Datos;
using Sistema.Entidades;

namespace Sistema.Negocio
{
    public class N_Biometrico
    {
        public static DataTable Listar()
        {
            D_Biometrico datos = new D_Biometrico();
            return datos.Listar();
        }

        public static DataTable Buscar(string valor)
        {
            D_Biometrico datos = new D_Biometrico();
            return datos.Buscar(valor);
        }

        public static List<Biometrico> ListarActivos()
        {
            D_Biometrico datos = new D_Biometrico();
            return datos.ListarActivos();
        }

        public static Biometrico ObtenerPorId(int id)
        {
            D_Biometrico datos = new D_Biometrico();
            return datos.ObtenerPorId(id);
        }

        public static string Insertar(string nombre, string ip, int puerto, int commKey, string ubicacion, string modelo, string numeroSerie, bool activo)
        {
            if (string.IsNullOrWhiteSpace(nombre)) return "El nombre del biométrico es obligatorio.";
            if (string.IsNullOrWhiteSpace(ip)) return "La dirección IP es obligatoria.";
            if (puerto <= 0) puerto = 4370;

            D_Biometrico datos = new D_Biometrico();
            Biometrico bio = new Biometrico
            {
                Nombre = nombre.Trim(),
                DireccionIP = ip.Trim(),
                Puerto = puerto,
                CommKey = commKey,
                Ubicacion = ubicacion?.Trim(),
                Modelo = modelo?.Trim(),
                NumeroSerie = numeroSerie?.Trim(),
                Activo = activo
            };
            return datos.Insertar(bio);
        }

        public static string Actualizar(int idBiometrico, string nombre, string ip, int puerto, int commKey, string ubicacion, string modelo, string numeroSerie, bool activo)
        {
            if (idBiometrico <= 0) return "ID de biométrico inválido.";
            if (string.IsNullOrWhiteSpace(nombre)) return "El nombre del biométrico es obligatorio.";
            if (string.IsNullOrWhiteSpace(ip)) return "La dirección IP es obligatoria.";
            if (puerto <= 0) puerto = 4370;

            D_Biometrico datos = new D_Biometrico();
            Biometrico bio = new Biometrico
            {
                IdBiometrico = idBiometrico,
                Nombre = nombre.Trim(),
                DireccionIP = ip.Trim(),
                Puerto = puerto,
                CommKey = commKey,
                Ubicacion = ubicacion?.Trim(),
                Modelo = modelo?.Trim(),
                NumeroSerie = numeroSerie?.Trim(),
                Activo = activo
            };
            return datos.Actualizar(bio);
        }

        public static string ActualizarEstado(int id, string estado, DateTime? ultimaSync = null, string modelo = null, string numeroSerie = null, int? usuarios = null, int? logs = null, int? huellas = null)
        {
            D_Biometrico datos = new D_Biometrico();
            return datos.ActualizarEstado(id, estado, ultimaSync, modelo, numeroSerie, usuarios, logs, huellas);
        }

        public static string Eliminar(int id)
        {
            D_Biometrico datos = new D_Biometrico();
            return datos.Eliminar(id);
        }
    }
}

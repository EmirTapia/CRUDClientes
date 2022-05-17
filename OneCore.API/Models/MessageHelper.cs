namespace OneCore.API.Models
{
    public static class MessageHelper
    {
        public static string GenerateMessage(MessageType messageType)
        {
            string result = string.Empty;
            switch (messageType)
            {
                case MessageType.RegistroClienteExitoso:
                    result = "El cliente se ha registrado de forma correcta.";
                    break;
                case MessageType.RegistroClienteFallido:
                    result = "Ocurrió un error al registrar un nuevo cliente.";
                    break;
                case MessageType.ActualizacionClienteExitoso:
                    result = "La modificación del cliente ha sido correcta.";
                    break;
                case MessageType.ActualizacionClienteFallido:
                    result = "La modificación del cliente ha fallado.";
                    break;
                case MessageType.EliminacionClienteExitoso:
                    result = "La eliminación del cliente ha sido correcta.";
                    break;
                case MessageType.EliminacionClienteFallido:
                    result = "La modificación del cliente ha fallado.";
                    break;
                case MessageType.CargaProductosExitoso:
                    result = "La carga de productos ha sido éxitosa.";
                    break;
                case MessageType.CargaProductosFallido:
                    result = "La carga de productos ha fallado.";
                    break;
                case MessageType.EnvioCorreoExitoso:
                    result = "El envío de correo ha sido éxitoso.";
                    break;
                case MessageType.EnvioCorreoFallido:
                    result = "El envío de correo ha fallado.";
                    break;
                case MessageType.Excepcion:
                    result = "Ocurrió un error: '{0}'.";
                    break;
                case MessageType.ObtenerClientesExitoso:
                    result = "La obtención de cliente/clientes ha sido éxitosa.";
                    break;
                case MessageType.ObtenerClientesFallido:
                    result = "No se obtuvieron los datos de cliente/clientes.";
                    break;
                case MessageType.ObtenerProductosExitoso:
                    result = "La obtención de productos ha sido éxitosa.";
                    break;
                case MessageType.ObtenerProductosFallido:
                    result = "No se obtuvieron los datos de productos.";
                    break;
            }

            return result;
        }
    }

    public enum MessageType
    {
        RegistroClienteExitoso = 1,
        RegistroClienteFallido,
        ActualizacionClienteExitoso,
        ActualizacionClienteFallido,
        EliminacionClienteExitoso,
        EliminacionClienteFallido,
        CargaProductosExitoso,
        CargaProductosFallido,
        EnvioCorreoExitoso,
        EnvioCorreoFallido,
        Excepcion,
        ObtenerClientesExitoso,
        ObtenerClientesFallido, 
        ObtenerProductosExitoso,
        ObtenerProductosFallido
    }
}

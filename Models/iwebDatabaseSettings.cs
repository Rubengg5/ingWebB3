﻿namespace WebAPI.Models;

public class iwebDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string UsuariosCollectionName { get; set; } = null!;

    public string MensajesCollectionName { get; set; } = null!;
}
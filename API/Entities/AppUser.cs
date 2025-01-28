using System;

namespace API.Entities;

//va a representar una tabla en la BD
public class AppUser
{
    //si no se llama id, hay que poner encima [key]
public int Id { get; set; }

public required string UserName {get; set;}

public required byte[] PasswordHash {get; set;}
public required byte[] PasswordSalt {get; set;} 

}


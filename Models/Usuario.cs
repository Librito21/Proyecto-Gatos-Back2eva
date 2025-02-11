namespace Models;

public class Usuario {

    public int Id_Usuario {get; set;}
    public string Nombre {get; set;} = "";
    public string Apellido {get; set;} = "";
    public string Email {get; set;} = "";
    public string Telefono {get; set;} = "";

    public Usuario() {}

    public Usuario(string nombre, string apellido, string email, string telefono) {
        Nombre = nombre;
        Apellido = apellido;
        Email = email;
        Telefono = telefono;
    }

    public void MostrarDetalles() {
        Console.WriteLine($"Usuario: {Nombre} {Apellido}, Email: {Email}, Teléfono: {Telefono}");
    }
}

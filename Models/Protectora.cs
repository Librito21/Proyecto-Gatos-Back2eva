namespace Models;

public class Protectora {

    public int Id_Protectora {get; set;}
    public string Nombre_Protectora {get; set;} = "";
    public string Direccion {get; set;} = "";
    public string Telefono {get; set;} = "";
    public string Email {get; set;} = "";

    public Protectora() {}

    public Protectora(string nombre_Protectora, string direccion, string telefono, string email) {
        Nombre_Protectora = nombre_Protectora;
        Direccion = direccion;
        Telefono = telefono;
        Email = email;
    }

    public void MostrarDetalles() {
        Console.WriteLine($"Protectora: {Nombre_Protectora}, Dirección: {Direccion}, Teléfono: {Telefono}, Email: {Email}");
    }
}

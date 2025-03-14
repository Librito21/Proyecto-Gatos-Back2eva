namespace Models;

public class Perro {

    public int Id_Perro {get; set;}
    public int Id_Protectora {get; set;}
    public string Nombre_Perro {get; set;} = "";
    public string Raza {get; set;} = "";
    public int Edad {get; set;}
    public bool Esterilizado {get; set;}
    public string Sexo {get; set;} = "";
    public string Descripcion_Perro {get; set;} = "";
    public string Imagen_Perro {get; set;} = "";

    public Perro() {}

    public Perro(int id_Protectora, string nombre_Perro, string raza, int edad, bool esterilizado, string sexo, string descripcion_Perro, string imagen_Perro) {
        Id_Protectora = id_Protectora;
        Nombre_Perro = nombre_Perro;
        Raza = raza;
        Edad = edad;
        Esterilizado = esterilizado;
        Sexo = sexo;
        Descripcion_Perro = descripcion_Perro;
        Imagen_Perro = imagen_Perro;
    }

    public void MostrarDetalles() {
        string estadoEsterilizado = Esterilizado ? "Sí" : "No";
        Console.WriteLine($"Perro: {Nombre_Perro}, Raza: {Raza}, Edad: {Edad} años, Esterilizado: {estadoEsterilizado}, Sexo: {Sexo}");
        Console.WriteLine($"Descripción: {Descripcion_Perro}");
    }
}

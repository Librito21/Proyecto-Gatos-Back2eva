namespace Models;

public class Deseado {

    public int Id_Deseado {get; set;}
    public int Id_Usuario {get; set;}
    public int Id_Gato {get; set;}
    public DateTime FechaDeseo {get; set;}

    public Deseado() {
        FechaDeseo = DateTime.Now;
    }

    public Deseado(int id_Usuario, int id_Gato) {
        Id_Usuario = id_Usuario;
        Id_Gato = id_Gato;
        FechaDeseo = DateTime.Now;
    }

    public void MostrarDetalles() {
        Console.WriteLine($"Usuario {Id_Usuario} ha añadido al gato {Id_Gato} a su lista de deseos el {FechaDeseo:dd/MM/yyyy}");
    }
}

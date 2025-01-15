using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vet.Clinique.Models;

public class DatabaseHelper
{
    private readonly SQLiteAsyncConnection _database;

    public DatabaseHelper(string dbPath)
    {
        // Inițializează conexiunea cu baza de date
        _database = new SQLiteAsyncConnection(dbPath);

        // Creează tabelele dacă nu există deja
        _database.CreateTableAsync<Pacient>().Wait();
        _database.CreateTableAsync<Programare>().Wait();
        _database.CreateTableAsync<Veterinar>().Wait();
    }

    // Operații CRUD pentru Pacient
    public Task<List<Pacient>> GetPacientiAsync() => _database.Table<Pacient>().ToListAsync();
    public Task<int> SavePacientAsync(Pacient pacient) => _database.InsertAsync(pacient);
    public Task<int> DeletePacientAsync(Pacient pacient) => _database.DeleteAsync(pacient);

    // Operații CRUD pentru Programare
    public Task<List<Programare>> GetProgramariAsync() => _database.Table<Programare>().ToListAsync();
    public Task<int> SaveProgramareAsync(Programare programare) => _database.InsertAsync(programare);
    public Task<int> DeleteProgramareAsync(Programare programare) => _database.DeleteAsync(programare);

    // Operații CRUD pentru Veterinar
    public Task<List<Veterinar>> GetVeterinariAsync() => _database.Table<Veterinar>().ToListAsync();
    public Task<int> SaveVeterinarAsync(Veterinar veterinar) => _database.InsertAsync(veterinar);
    public Task<int> DeleteVeterinarAsync(Veterinar veterinar) => _database.DeleteAsync(veterinar);
}


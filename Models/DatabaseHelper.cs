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
        _database = new SQLiteAsyncConnection(dbPath);

        _database.CreateTableAsync<Pacient>().Wait();
        _database.CreateTableAsync<Programare>().Wait();
        _database.CreateTableAsync<Veterinar>().Wait();
    }

    public Task<List<Pacient>> GetPacientiAsync() => _database.Table<Pacient>().ToListAsync();
    public Task<int> SavePacientAsync(Pacient pacient) => _database.InsertAsync(pacient);
    public Task<int> DeletePacientAsync(Pacient pacient) => _database.DeleteAsync(pacient);

    public Task<List<Programare>> GetProgramariAsync() => _database.Table<Programare>().ToListAsync();
    public Task<int> SaveProgramareAsync(Programare programare) => _database.InsertAsync(programare);
    public Task<int> DeleteProgramareAsync(Programare programare) => _database.DeleteAsync(programare);

    public Task<List<Veterinar>> GetVeterinariAsync() => _database.Table<Veterinar>().ToListAsync();
    public Task<int> SaveVeterinarAsync(Veterinar veterinar) => _database.InsertAsync(veterinar);
    public Task<int> DeleteVeterinarAsync(Veterinar veterinar) => _database.DeleteAsync(veterinar);

    public Task<List<Veterinar>> GetMediciAsync() => _database.Table<Veterinar>().ToListAsync();

    public Task<int> UpdatePacientAsync(Pacient pacient) => _database.UpdateAsync(pacient);
    public Task<int> UpdateMedicAsync(Veterinar veterinar) => _database.UpdateAsync(veterinar);
    public Task<int> UpdateProgramareAsync(Programare programare) => _database.UpdateAsync(programare);

    public async Task<List<ProgramareDTO>> GetProgramariWithDetailsAsync()
    {

        var programari = await _database.Table<Programare>().ToListAsync();
        var pacienti = await _database.Table<Pacient>().ToListAsync();
        var medici = await _database.Table<Veterinar>().ToListAsync();

        // Corectarea mapării
        var programariDTO = programari
            .Join(pacienti, p => p.PacientID, pac => pac.ID, (p, pac) => new { p, pac })
            .Join(medici, pp => pp.p.VeterinarID, m => m.ID, (pp, m) => new ProgramareDTO
            {
                NumePacient = pp.pac.NumePacient,
                NumeMedic = m.NumeMedic,
                DataProgramarii = pp.p.DataProgramarii
            })
            .ToList();

        return programariDTO;
    }

    public Task<int> DeleteAllProgramariAsync()
    {
        return _database.DeleteAllAsync<Programare>();
    }

}


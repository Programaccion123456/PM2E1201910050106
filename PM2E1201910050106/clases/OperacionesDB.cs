using PM2E1201910050106.model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PM2E1201910050106.clases
{
    public class OperacionesDB
    {
        cnx conn = new cnx();

        public Task<List<Modelo>> getReadUbicacion()
        {
            return conn.GetAsyncConnection().Table<Modelo>().ToListAsync();
        }

        public Task<Modelo> getUbicacionId(int id)
        {
            return conn
                .GetAsyncConnection()
                .Table<Modelo>()
                .Where(item => item.id == id)
                .FirstOrDefaultAsync();
        }

        public Task<int> getUbicacionUpdateId(Modelo ubicacion)
        {
            return conn
                .GetAsyncConnection()
                .UpdateAsync(ubicacion);

        }

        public Task<int> Delete(Modelo ubicacion)
        {
            return conn
                .GetAsyncConnection()
                .DeleteAsync(ubicacion);
        }

    }
}

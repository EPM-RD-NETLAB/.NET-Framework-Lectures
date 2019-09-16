using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalizableDisposableClass
{
    // Сложный упаковщик ресурсов. 
    class MyResourceWrapper : IDisposable
    {
        // Сборщик мусора будет вызывать этот метод, если 
        // пользователь объекта забыл вызвать метод Dispose(). 
        // Используется для выяснения того, вызывался ли уже метод Dispose () . 
        private bool disposed = false;

        public void Dispose()
        {
            // Вызов вспомогательного метода. 
            // Значение true указывает на то, что очистка 
            // была инициирована пользователем объекта. 
            CleanUp(true);

            // Подавление финализации. 
            GC.SuppressFinalize(this);
        }

        
        private void CleanUp(bool disposing)
        {
            // Проверка, выполнялась ли очистка. 
            if (!this.disposed)
            {
                // Если disposing равно true, должно осуществляться 
                // освобождение всех управляемых ресурсов, 
                if (disposing)
                {
                    // Здесь осуществляется освобождение управляемых ресурсов. 

                }
                // Очистка неуправляемых ресурсов. 
            }
            disposed = true;
        }

        ~MyResourceWrapper()
        {
            Console.Beep();
            // Вызов вспомогательного метода. 
            // Значение false указывает на то, что 
            // очистка была инициирована сборщиком мусора. 
            CleanUp(false);
        }

    }


}

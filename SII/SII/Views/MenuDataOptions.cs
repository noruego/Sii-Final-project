using SII.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SII.Views
{
    class MenuDataOptions : List<MenuOpcion>
    {
        public MenuDataOptions()
        {
            this.Add(new MenuOpcion()
            {
                Title = "Mis datos",
                IconSource = "data_icon.png",
                TargetType = typeof(DataPage)
            });
            this.Add(new MenuOpcion()
            {
                Title = "Materias",
                IconSource = "subject_icon.png",
                TargetType = typeof(SubjectsPage),
            });
            this.Add(new MenuOpcion()
            {
                Title = "Calificaciones",
                IconSource = "calification_icon.png",
               // TargetType = typeof(InstitucionesPage),
            });
            this.Add(new MenuOpcion()
            {
                Title = "Kardex",
                IconSource = "kardex_icon.png",
                TargetType = typeof(KardexPage),
            });
            this.Add(new MenuOpcion()
            {
                Title = "Cerrar sesión",
                IconSource = "count_icon.png",
                TargetType = typeof(CuentaPage),
            });

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataLayer.Entities;

namespace DataLayer
{
    public static class SampleData
    {
        public static void InitData(EFDBContext context)
        {
            if (!context.Directories.Any())
            {
                context.Directories.Add(new Directory()
                {
                    Title = "Первый раздел", Html = "<h4>Введение в технологию ASP.NET</h4>"
                });
                context.Directories.Add(new Directory()
                {
                    Title = "Второй раздел",
                    Html = "<h4>Особенности ASP.NET WebForms</h4>"
                });
                context.Directories.Add(new Directory()
                {
                    Title = "Третий раздел",
                    Html = "<h4>Преимущества ASP.NET Core</h4>"
                });

                context.SaveChanges();

                if (!context.Materials.Any())
                {
                    context.Materials.Add(new Material()
                    {
                        Title = "Параграф-1", Html = "Аннотация-1", DirectoryId = 1
                    });
                    context.Materials.Add(new Material()
                    {
                        Title = "Параграф-2", Html = "Аннотация-2", DirectoryId = 1
                    });

                    context.Materials.Add(new Material()
                    {
                        Title = "Параграф-3", Html = "Аннотация-3", DirectoryId = 2
                    });
                    context.Materials.Add(new Material()
                    {
                        Title = "Параграф-4", Html = "Аннотация-4", DirectoryId = 2
                    });

                    context.Materials.Add(new Material()
                    {
                        Title = "Параграф-5", Html = "Аннотация-5", DirectoryId = 3
                    });
                    context.Materials.Add(new Material()
                    {
                        Title = "Параграф-6", Html = "Аннотация-6", DirectoryId = 3
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}

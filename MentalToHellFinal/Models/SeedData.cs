using MentalToHellFinal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentalToHellFinal.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                if(context.Genders.Any())
                {
                    return;
                }
                else if(context.Religions.Any())
                {
                    return;
                }
                else if(context.Sexes.Any())
                {
                    return;
                }
                else if(context.Temperaments.Any())
                {
                    return;
                }
                else
                {
                    context.SaveChanges();
                }

                context.Genders.AddRange(
                    new CustomUser.MISC.Gender
                    {
                        GenderName = "Мужской"
                    },
                    new CustomUser.MISC.Gender
                    {
                        GenderName = "Женский"
                    },
                    new CustomUser.MISC.Gender
                    {
                        GenderName = "Трансгендер"
                    },
                    new CustomUser.MISC.Gender
                    {
                        GenderName = "Другой"
                    }
                    );

                context.Religions.AddRange(
                    new CustomUser.MISC.Religion
                    {
                        ReligionType = "1 Христианство"
                    },
                    new CustomUser.MISC.Religion
                    {
                        ReligionType = "1.1 Протестантизм"
                    },
                    new CustomUser.MISC.Religion
                    {
                        ReligionType = "1.2 Католицизм"
                    },
                    new CustomUser.MISC.Religion
                    {
                        ReligionType = "1.3 Православие"
                    },
                    new CustomUser.MISC.Religion
                    {
                        ReligionType = "2 Ислам"
                    },
                    new CustomUser.MISC.Religion
                    {
                        ReligionType = "2.1 Сунниты"
                    },
                    new CustomUser.MISC.Religion
                    {
                        ReligionType = "2.2 Шииты"
                    },
                    new CustomUser.MISC.Religion
                    {
                        ReligionType = "2.3 Ибадиты"
                    },
                    new CustomUser.MISC.Religion
                    {
                        ReligionType = "2.4 Ахмадиты"
                    },
                    new CustomUser.MISC.Religion
                    {
                        ReligionType = "3 Атеисты"
                    },
                    new CustomUser.MISC.Religion
                    {
                        ReligionType = "4 Агностики"
                    },
                    new CustomUser.MISC.Religion
                    {
                        ReligionType = "5 Неверующие"
                    },
                    new CustomUser.MISC.Religion
                    {
                        ReligionType = "6 Индуизм"
                    },
                    new CustomUser.MISC.Religion
                    {
                        ReligionType = "6.1 Вишнуизм"
                    },
                    new CustomUser.MISC.Religion
                    {
                        ReligionType = "6.2 Шиваизм"
                    },
                    new CustomUser.MISC.Religion
                    {
                        ReligionType = "6.3 Смартизм"
                    },
                    new CustomUser.MISC.Religion
                    {
                        ReligionType = "6.4  Шактизм"
                    },
                    new CustomUser.MISC.Religion
                    {
                        ReligionType = "7 Буддизм"
                    },
                    new CustomUser.MISC.Religion
                    {
                        ReligionType = "7.1 Махаяна"
                    },
                    new CustomUser.MISC.Religion
                    {
                        ReligionType = "7.2 Хинаяна"
                    },
                    new CustomUser.MISC.Religion
                    {
                        ReligionType = "7.3 Тхеравада"
                    },
                    new CustomUser.MISC.Religion
                    {
                        ReligionType = "7.4 Варджаяна"
                    },
                    new CustomUser.MISC.Religion
                    {
                        ReligionType = "8 Религия народов Китая"
                    },
                    new CustomUser.MISC.Religion
                    {
                        ReligionType = "9 Этнические религии"
                    },
                    new CustomUser.MISC.Religion
                    {
                        ReligionType = "10 Традиционные африканские религии"
                    },
                    new CustomUser.MISC.Religion
                    {
                        ReligionType = "11 Сикхизм"
                    },
                    new CustomUser.MISC.Religion
                    {
                        ReligionType = "12 Спиритизм"
                    },
                    new CustomUser.MISC.Religion
                    {
                        ReligionType = "13 Иудаизм"
                    }
                    );

                context.Sexes.AddRange(
                    new CustomUser.MISC.Sex
                    {
                        SexName="Мужской"
                    },
                    new CustomUser.MISC.Sex
                    {
                        SexName = "Женский"
                    },
                    new CustomUser.MISC.Sex
                    {
                        SexName = "Другое"
                    }
                    );

                context.Temperaments.AddRange(
                    new CustomUser.MISC.Temperament
                    {
                        TemperamentName = "Холерик"
                    },
                    new CustomUser.MISC.Temperament
                    {
                        TemperamentName = "Флегматик"
                    },
                    new CustomUser.MISC.Temperament
                    {
                        TemperamentName = "Меланхолик"
                    },
                    new CustomUser.MISC.Temperament
                    {
                        TemperamentName = "Сангвиник"
                    }
                    );

                context.SaveChanges();
            }
        }
    }
}

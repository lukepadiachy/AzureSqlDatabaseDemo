using AzureSqlDatabaseDemo.Data;
using AzureSqlDatabaseDemo.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();

builder.Services.AddDbContext<ArtistContext>(options => options.UseAzureSql(builder.Configuration.GetConnectionString("AzureSqlConnectionString")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ArtistContext>();
    context.Database.Migrate();

    if (!context.Artists.Any())
    {
        context.Artists.AddRange(
            new Artist
            {
                Name = "Lena Rivers",
                Genre = "Indie Folk",
                Country = "USA",
                Biography = "Lena Rivers is an acclaimed indie folk singer-songwriter from Portland, Oregon, known for her poetic lyrics and soulful acoustic performances. She began her career busking in city parks before releasing her debut album, 'Whispering Pines', in 2015."
            },
            new Artist
            {
                Name = "Mateo Alvarez",
                Genre = "Latin Pop",
                Country = "Argentina",
                Biography = "Mateo Alvarez is a chart-topping Latin pop artist from Buenos Aires. His energetic stage presence and catchy melodies have earned him multiple awards across South America since his breakout single 'Bailar Contigo' in 2018."
            },
            new Artist
            {
                Name = "Sophie Dubois",
                Genre = "Chanson",
                Country = "France",
                Biography = "Sophie Dubois is a Parisian singer celebrated for reviving the classic French chanson style. Her evocative voice and modern arrangements have captivated audiences throughout Europe."
            },
            new Artist
            {
                Name = "Akira Sato",
                Genre = "J-Pop",
                Country = "Japan",
                Biography = "Akira Sato is a J-Pop sensation from Tokyo, blending traditional Japanese instruments with contemporary pop sounds. He rose to fame with his hit single 'Sakura Dreams' in 2020."
            },
            new Artist
            {
                Name = "Nia Okafor",
                Genre = "Afrobeat",
                Country = "Nigeria",
                Biography = "Nia Okafor is a dynamic Afrobeat artist from Lagos, known for her powerful vocals and socially conscious lyrics. Her music fuses traditional rhythms with modern electronic elements."
            },
            new Artist
            {
                Name = "Elena Petrova",
                Genre = "Classical",
                Country = "Russia",
                Biography = "Elena Petrova is a renowned classical pianist from Moscow. She has performed with leading orchestras worldwide and is celebrated for her interpretations of Rachmaninoff and Tchaikovsky."
            },
            new Artist
            {
                Name = "Tommy O'Connor",
                Genre = "Folk Rock",
                Country = "Ireland",
                Biography = "Tommy O'Connor is an Irish folk rock musician whose storytelling and guitar work have made him a staple in Dublin's music scene. His album 'Emerald Roads' received critical acclaim in 2021."
            },
            new Artist
            {
                Name = "Priya Sharma",
                Genre = "Bollywood",
                Country = "India",
                Biography = "Priya Sharma is a Bollywood playback singer from Mumbai, known for her versatile voice and emotive performances in numerous blockbuster films."
            },
            new Artist
            {
                Name = "Lucas Meyer",
                Genre = "Electronic",
                Country = "Germany",
                Biography = "Lucas Meyer is a Berlin-based electronic music producer and DJ, recognized for his innovative soundscapes and energetic live sets at major European festivals."
            },
            new Artist
            {
                Name = "Ava Thompson",
                Genre = "Country",
                Country = "Australia",
                Biography = "Ava Thompson is a country singer-songwriter from Sydney, blending traditional country with modern pop influences. Her heartfelt lyrics resonate with fans across Australia."
            },
            new Artist
            {
                Name = "Mikhail Ivanov",
                Genre = "Jazz",
                Country = "Russia",
                Biography = "Mikhail Ivanov is a jazz saxophonist from Saint Petersburg, known for his improvisational skills and collaborations with international jazz legends."
            },
            new Artist
            {
                Name = "Sara Kim",
                Genre = "K-Pop",
                Country = "South Korea",
                Biography = "Sara Kim is a leading K-Pop idol, admired for her powerful vocals and dynamic dance routines. She debuted with the group 'Starlight' in 2019."
            },
            new Artist
            {
                Name = "David Müller",
                Genre = "Rock",
                Country = "Germany",
                Biography = "David Müller is the frontman of the German rock band 'Iron Echoes', known for their high-energy performances and anthemic choruses."
            },
            new Artist
            {
                Name = "Isabella Rossi",
                Genre = "Opera",
                Country = "Italy",
                Biography = "Isabella Rossi is a celebrated Italian soprano, performing leading roles in major opera houses across Europe. Her voice is praised for its clarity and emotional depth."
            },
            new Artist
            {
                Name = "Carlos Mendes",
                Genre = "Samba",
                Country = "Brazil",
                Biography = "Carlos Mendes is a samba musician from Rio de Janeiro, famous for his infectious rhythms and vibrant performances during Carnival."
            },
            new Artist
            {
                Name = "Emily Carter",
                Genre = "Blues",
                Country = "USA",
                Biography = "Emily Carter is a blues guitarist and singer from Memphis, Tennessee. Her soulful voice and expressive guitar playing have earned her a loyal following."
            },
            new Artist
            {
                Name = "Yusuf Demir",
                Genre = "Hip Hop",
                Country = "Turkey",
                Biography = "Yusuf Demir is a pioneering Turkish hip hop artist, blending traditional Anatolian sounds with modern beats and thought-provoking lyrics."
            },
            new Artist
            {
                Name = "Anna Svensson",
                Genre = "Pop",
                Country = "Sweden",
                Biography = "Anna Svensson is a Swedish pop star, known for her catchy hooks and energetic performances. She represented Sweden in the Eurovision Song Contest."
            },
            new Artist
            {
                Name = "Liam Evans",
                Genre = "Alternative",
                Country = "UK",
                Biography = "Liam Evans is a British alternative rock musician, acclaimed for his introspective songwriting and innovative guitar work."
            },
            new Artist
            {
                Name = "Chloe Martin",
                Genre = "R&B",
                Country = "Canada",
                Biography = "Chloe Martin is a Canadian R&B singer-songwriter, recognized for her smooth vocals and emotionally charged lyrics."
            }
        );
        context.SaveChanges();
    }
}



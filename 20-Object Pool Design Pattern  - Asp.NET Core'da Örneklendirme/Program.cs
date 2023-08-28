using _20_Object_Pool_Design_Pattern____Asp.NET_Core_da_Örneklendirme;
using Microsoft.Extensions.ObjectPool;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Microsoft.Extensions.ObjectPool
builder.Services.AddSingleton<ObjectPoolProvider, DefaultObjectPoolProvider>();
builder.Services.AddSingleton(p =>
{
    var provider = p.GetService<ObjectPoolProvider>();
    return provider.Create<X>();
});

builder.Services.AddSingleton(p =>
{
    var provider = p.GetService<ObjectPoolProvider>();
    return provider.Create<Y>();
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


/*
 Burada kutuphane ýndýrmeye gerek yoktur zaten halý hazýrda ýnýk gelýcektýr tek yapýlmasý gereken usteký tanýmlamayý ypmak 
 */
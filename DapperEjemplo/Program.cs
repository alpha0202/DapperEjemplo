
using Dapper;
using DapperEjemplo;
using System.Data;
using System.Data.SqlClient;

using (SqlConnection sql = new SqlConnection("Data Source =EC04267; Initial Catalog=WEBAPI_DAPPER;User Id=sa;Password=1234"))

{
    //trabajar con SP, insertar

    Prueba p = new Prueba();

    p.NOMBRE = "TESTING SP";
    var param = new DynamicParameters();
    param.Add("@Nombre", p.NOMBRE);
    sql.ExecuteScalar("EjemploInsert", param,commandType: CommandType.StoredProcedure);



    //SP SIN PARÁMETROS
    var r = sql.ExecuteReader("Ejemplo", commandType: CommandType.StoredProcedure);
    while (r.Read())
        Console.WriteLine(r["Nombre"]);

    r.Close();

    Console.WriteLine("--------------------------------");
    //CON PARÁMETROS
    var parametro =new DynamicParameters();
    parametro.Add("@id", 4);
    r = sql.ExecuteReader("Ejemplo", parametro, commandType: CommandType.StoredProcedure);
   
    while (r.Read())
        Console.WriteLine(r["Nombre"]);

    r.Close();

















    ////insertar data
    // Prueba prueba = new Prueba();

    // prueba.NOMBRE = "Samuel";

    //var insertar = "insert into dbo.PRUEBA(NOMBRE) values(@NOMBRE)";
    //var res = sql.Execute(insertar,prueba);


    ////actualizar
    //prueba.NOMBRE = "manolo";
    //var actualizar = "update dbo.PRUEBA set NOMBRE = @NOMBRE where NOMBRE = 'ana' ";
    //res = sql.Execute(actualizar,prueba);



    ////eliminar
    //prueba.NOMBRE = "manolo";
    //var borrar = "delete from dbo.PRUEBA where NOMBRE = @NOMBRE";
    //res = sql.Execute(borrar,prueba); 


    ////listar datos 
    //var consulta = "select * from prueba";
    //var lista = sql.Query<Prueba>(consulta);

    //foreach (var p in lista)
    //{
    //    Console.WriteLine(p.ID + " " + p.NOMBRE);
    //}

    //Console.WriteLine("pulsar para continuar");
    //Console.ReadLine();
} 
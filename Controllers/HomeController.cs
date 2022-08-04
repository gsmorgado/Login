using Login.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

using Microsoft.AspNetCore.Authorization;

namespace Login.Controllers
{
    // Restringe acceso 
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Action Form Test
        /// </summary>
        /// <returns></returns>
        public IActionResult Test()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
        /// <summary>
        /// Action Calculo Test  
        /// </summary>
        /// <param name="_test"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Test(Test _test)
        {
            if (_test.Numero > 0)
            {
                ViewBag.letra = ConvertirNumLetras(_test.Numero);
            }
            else {
                ViewData["Mensaje"] = "Solo números postivos!";
            }
            return View();     

        }
        /// <summary>
        /// Convertir Numero a letras
        /// </summary>
        /// <param name="number"></param>
        /// <returns>
        /// Devuelve un string con 
        /// </returns>
        public static string ConvertirNumLetras(long number) 
        {
            var resultado = "";
            try {               
                long numeroResta;
                long newnumber;
                switch (number)
                {
                    case 1:
                        resultado = "uno";
                        break;
                    case 2:
                        resultado = "dos";
                        break;
                    case 3:
                        resultado = "tres";
                        break;
                    case 4:
                        resultado = "cuatro";
                        break;
                    case 5:
                        resultado = "cinco";
                        break;
                    case 6:
                        resultado = "seis";
                        break;
                    case 7:
                        resultado = "siete";
                        break;
                    case 8:
                        resultado = "ocho";
                        break;
                    case 9:
                        resultado = "nueve";
                        break;
                    case 10:
                        resultado = "diez";
                        break;
                    case 11:
                        resultado = "once";
                        break;
                    case 12:
                        resultado = "doce";
                        break;
                    case 13:
                        resultado = "trece";
                        break;
                    case 14:
                        resultado = "catorce";
                        break;
                    case 15:
                        resultado = "quince";
                        break;
                    case > 15 and < 20:
                        numeroResta = number - 10;
                        resultado = "Dieci" + ConvertirNumLetras(numeroResta);
                        break;
                    case 20:
                        resultado = "veinte";
                        break;
                    case > 20 and < 30:
                        numeroResta = number - 20;
                        resultado = "veinti" + ConvertirNumLetras(numeroResta);
                        break;
                    case 30:
                        resultado = "treinta";
                        break;
                    case > 30 and < 40:
                        numeroResta = number - 30;
                        resultado = "treinta y " + ConvertirNumLetras(numeroResta);
                        break;
                    case 40:
                        resultado = "cuarenta";
                        break;
                    case > 40 and < 50:
                        numeroResta = number - 40;
                        resultado = "cuarenta y " + ConvertirNumLetras(numeroResta);
                        break;
                    case 50:
                        resultado = "cincuenta";
                        break;
                    case > 50 and < 60:
                        numeroResta = number - 50;
                        resultado = "cincuenta y " + ConvertirNumLetras(numeroResta);
                        break;
                    case 60:
                        resultado = "sesenta";
                        break;
                    case > 60 and < 70:
                        numeroResta = number - 60;
                        resultado = "sesenta y " + ConvertirNumLetras(numeroResta);
                        break;
                    case 70:
                        resultado = "setenta";
                        break;
                    case > 70 and < 80:
                        numeroResta = number - 70;
                        resultado = "setenta y " + ConvertirNumLetras(numeroResta);
                        break;
                    case 80:
                        resultado = "ochenta";
                        break;
                    case > 80 and < 90:
                        numeroResta = number - 80;
                        resultado = "ochenta y " + ConvertirNumLetras(numeroResta);
                        break;
                    case 90:
                        resultado = "noventa";
                        break;
                    case > 90 and < 100:
                        numeroResta = number - 90;
                        resultado = "noventa y " + ConvertirNumLetras(numeroResta);
                        break;
                    case 100:
                        resultado = "cien";
                        break;
                    case 200:
                        resultado = "doscientos";
                        break;
                    case 300:
                        resultado = "trescientos";
                        break;
                    case 400:
                        resultado = "cuatrocientos";
                        break;
                    case 500:
                        resultado = "quinientos";
                        break;
                    case 600:
                        resultado = "seiscientos";
                        break;
                    case 700:
                        resultado = "setecientos";
                        break;
                    case 800: // (number /100)
                        resultado = "ocho cientos";
                        break;
                    case 900:
                        resultado = "novecientos";
                        break;
                    case < 1000:
                        numeroResta = number % 100;
                        // se obtiene el valor entero
                        newnumber = number - numeroResta;
                        if (newnumber == 100) { resultado = "ciento " + " " + ConvertirNumLetras(numeroResta); } // ciento..uno..etc
                        else { resultado = ConvertirNumLetras(newnumber) + " " + ConvertirNumLetras(numeroResta); } // mayor que doscientos menor que mil
                        break;
                    case 1000:
                        resultado = "mil";
                        break;
                    case < 1000000:
                        long mil = number / 1000;
                        numeroResta = number % 1000;
                        newnumber = number - numeroResta;

                        if (number / 1000 == 1) { resultado = " mil " + ConvertirNumLetras(numeroResta); } // mil..uno..etc
                        else
                        {
                            if (numeroResta == 0) { resultado = ConvertirNumLetras(number / 1000) + " mil "; } // mayor que mil menor que un millon... dos mil .. tres mil.etc
                            else { resultado = ConvertirNumLetras(number / 1000) + " mil " + ConvertirNumLetras(numeroResta); } // 2345
                        }

                        break;
                    case 1000000:
                        resultado = "un millon";
                        break;
                    case < 2000000:
                        numeroResta = number % 1000000;
                        resultado = "un millon " + ConvertirNumLetras(numeroResta); 
                        break;
                    case < 1000000000000:
                        numeroResta = number % 1000000;
                        newnumber = number - numeroResta;
                        if (numeroResta == 0) { resultado = ConvertirNumLetras(number / 1000000) + " millones "; } // 2 000 000 
                        else { resultado = ConvertirNumLetras(number / 1000000) + " millones " + ConvertirNumLetras(numeroResta); } // 2345000,  99,999,999.. 999,999,999
                        break;
                    case 1000000000000:
                        resultado = " un billon";
                        break;
                    case < 2000000000000:
                        numeroResta = number % 1000000000000;
                        resultado = "un billon " + ConvertirNumLetras(numeroResta);
                        break;
                    case < 10000000000000:
                        numeroResta = number % 1000000000000;
                        newnumber = number - numeroResta;
                        if (numeroResta == 0) { resultado = ConvertirNumLetras(number / 1000000000000) + " billones "; } // 2 000 000 000 000
                        else { resultado = ConvertirNumLetras(number / 1000000000000) + " billones " + ConvertirNumLetras(numeroResta); } //   9,999,999,999,999
                        break;
                    default:
                        break;

                }

            }
            catch (Exception ex)
            {
              
            }
            
            return resultado.ToUpper();
        }
    }
}

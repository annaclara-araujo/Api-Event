namespace Api_Event.Utils
{
    public class Criptografia
    {

        
            public static string GerarHash(string senha)
            {
                return BCrypt.Net.BCrypt.HashPassword(senha);

            }

            public static bool CompararHash(string senhainformada, string senhaBanco)
            {
                return BCrypt.Net.BCrypt.Verify(senhainformada, senhaBanco);

            }




        }
    }


using System;
using System.Collections.Generic;

namespace Backend.Domain.Validations
{
    public static class DomainValidation
    {
        private static readonly List<Tuple<string, string>> _notifications = new List<Tuple<string, string>>();

        private static void AddNotification(string className, string errorMessage)
        {
            _notifications.Add(new Tuple<string, string>(className, errorMessage));
        }

        // Retorna as notificacoes e limpa os _notifications para uma nova Request
        // Apenas chamar essa funcao no retorno dos metodos da camada Application nos Services
        public static List<Tuple<string, string>> GetNotificationsAndClear()
        {
            lock (_notifications)
            {
                var Notifications = new List<Tuple<string, string>>(_notifications);

                _notifications.Clear();

                return Notifications;
            }
        }

        public static int Length()
        {
            lock (_notifications)
            {
                return _notifications.Count;
            }
        }

        public static void IsNullOrEmpty(string property, string value)
        {
            bool result = string.IsNullOrEmpty(value);

            if(result)
            {
                lock (_notifications)
                {
                    AddNotification(property, String.Format("ERRO - Valor é nulo ou vazio"));
                }
            }
        }

        public static void HasAt(string property, string value)
        {
            if(value.Contains("@") == false)
            {
                lock (_notifications)
                {
                    AddNotification(property, String.Format("ERRO - Valor inválido"));
                }
            }
        }

        public static void GreaterThanMaxLength(string property, string value, uint length)
        {
            if(value.Length > length)
            {
                lock(_notifications)
                {
                    AddNotification(property, String.Format("ERRO - Tamanho maior que o permitido"));
                }
            }
        }

        public static void LessThanMinLength(string property, string value, uint length)
        {
            if (value.Length < length)
            {
                lock (_notifications)
                {
                    AddNotification(property, String.Format("ERRO - Tamanho menor que o permitido"));
                }
            }
        }

        public static void HasNumber(string property, string value)
        {
            bool hasNumber = false;

            foreach(char c in value)
            {
                if(c == '0' || c == '1' || c == '2' || c == '3' || c == '4' ||
                   c == '5' || c == '6' || c == '7' || c == '8' || c == '9')
                {
                    hasNumber = true;
                }
            }

            if (hasNumber)
            {
                lock (_notifications)
                {
                    AddNotification(property, String.Format("ERRO - Não pode conter números"));
                }
            }
        }

        public static void IsValidRole(string property, string value)
        {
            if (value != "student" && value != "staff")
            {
                lock (_notifications)
                {
                    AddNotification(property, String.Format("ERRO - Valor não permitido"));
                }
            }
        }
    }
}

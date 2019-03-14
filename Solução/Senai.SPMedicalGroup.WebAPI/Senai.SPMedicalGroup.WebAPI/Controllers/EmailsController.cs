using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.SPMedicalGroup.WebAPI.Domains;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Senai.SPMedicalGroup.WebAPI.Controllers
{
    public class EmailsController
    {
        static EmailDomain email = new EmailDomain();

        static async Task EnviarEmail()
        {
            var apiKey = "@MyAPINumber";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("@MyEmail", "@MyName");
            var subject = "Parabéns por se cadastrar na SP Medical Group!!";
            var to = new EmailAddress(email.EmailDestinatario, email.NomeDestinatario);
            var plainTextContent = "Parabéns " + email.NomeDestinatario + "! Você acaba de se cadastrar na SP Medical Group com o perfil de " + email.TipoUsuario + ". Aplicação desenvolvida por Ariel Paixão, GitHub: https://github.com/arielmn22";
            var htmlContent = "Parabéns " + email.NomeDestinatario + "! Você acaba de se cadastrar na SP Medical Group com o perfil de " + email.TipoUsuario + ". Aplicação desenvolvida por Ariel Paixão, GitHub: https://github.com/arielmn22";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }

        public void Enviar(Usuarios usuario)
        {
            switch (usuario.IdTipoUsuario)
            {
                case 1:
                    email.TipoUsuario = "Administrador";
                    break;
                case 2:
                    email.TipoUsuario = "Médico";
                    break;
                case 3:
                    email.TipoUsuario = "Paciente";
                    break;
            }

            email.EmailDestinatario = usuario.Email;
            email.NomeDestinatario = usuario.Nome;

            EnviarEmail().Wait();
        }
    }
}
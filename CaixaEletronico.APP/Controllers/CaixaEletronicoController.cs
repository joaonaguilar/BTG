using CaixaEletronico.APP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaixaEletronico.APP.Controllers
{
    public class CaixaEletronicoController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(CaixaEletronicoModel caixaEletronico)
        {
            int valorNota100 = caixaEletronico.quantidade100 * 100;
            int valorNota50 = caixaEletronico.quantidade50 * 50;
            int valorNota20 = caixaEletronico.quantidade20 * 20;
            int valorNota10 = caixaEletronico.quantidade10 * 10;

            int valorTotal = valorNota100 + valorNota50 + valorNota20 + valorNota10;
            int valorFaltante = caixaEletronico.valor;

            if (caixaEletronico.valor > valorTotal)
            {
                ViewBag.Error = "Valor de saque maior que o valor pela quantidade de notas!";
                return View();
            }

            int[] cedula = new int[] { 100, 50, 20, 10 };
            int[] quantidade = new int[] { caixaEletronico.quantidade100, caixaEletronico.quantidade50, caixaEletronico.quantidade20, caixaEletronico.quantidade10 };
            List<Final> listaFinal = new List<Final>();

            for (int i = 0; i < cedula.Length; i++)
            {
                int total = 0;

                while (valorFaltante >= cedula[i])
                {
                    if (quantidade[i] > 0)
                    {
                        if (valorFaltante >= cedula[i])
                        {
                            total++;
                            quantidade[i]--;
                            valorFaltante -= cedula[i];
                            continue;
                        }
                    }
                    else
                        break;
                }

                if (total > 0)
                    listaFinal.Add(new Final(cedula[i], total));
            }

            if (valorFaltante > 0)
            {
                ViewBag.Error = "Não há notas compatíveis para este valor de saque!";
                return View();
            }

            ViewBag.Sucesso = "Sucesso";
            ViewBag.Lista = listaFinal;

            return View();
        }
    }
}

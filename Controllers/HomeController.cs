using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BitcoinWallet.Models;
using Microsoft.AspNetCore.Identity;
using BitcoinWallet.Data;
using NBitcoin;
using QBitNinja.Client;

namespace BitcoinWallet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _logger = logger;
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> IndexAsync()
        {

            var user = await _userManager.GetUserAsync(HttpContext.User);
            var adress = _context.UserDetails.FirstOrDefault(item => item.user_id == Guid.Parse(user.Id));
            var wallet_pk = adress.user_adress;
            PubKey temp_pk = new PubKey(wallet_pk);
            ViewBag.adress = temp_pk.GetAddress(ScriptPubKeyType.Legacy, Network.TestNet);


            return View();
        }


        public async Task<IActionResult> SendBTC()
        {

            var user = await _userManager.GetUserAsync(HttpContext.User);
            var adress = _context.UserDetails.FirstOrDefault(item => item.user_id == Guid.Parse(user.Id));
            var wallet_pk = adress.user_adress;


            var bitcoinPrivateKey = new BitcoinSecret(wallet_pk, Network.TestNet);
            var network = bitcoinPrivateKey.Network;
            var address = bitcoinPrivateKey.GetAddress(ScriptPubKeyType.Legacy);


















            return View();
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

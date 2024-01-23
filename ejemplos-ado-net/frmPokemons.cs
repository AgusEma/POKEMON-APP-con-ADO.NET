using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ejemplos_ado_net
{
    public partial class frmPokemons : Form
    {
        public frmPokemons()
        {
            InitializeComponent();
        }

        //Invoco la lectura (ya construida) a base de datos:
        private void frmPokemons_Load(object sender, EventArgs e)
        {
                
            PokemonNegocio negocio = new PokemonNegocio();
            //DataSource recibe un origen de datos y lo modela en la tabla:
            dgvPokemons.DataSource = negocio.listar();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
  
    public class Paquete : IMostrar<Paquete>
    {
        #region Delegados
        public delegate void DelegadoEstado(object sender, EventArgs e);
        #endregion

        #region Eventos
        public event DelegadoEstado InformaEstado;
        #endregion

        #region Enumerados
        public enum EEstado
        {
            Ingresado, EnViaje, Entregado
        }
        #endregion

        #region Atributos
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        #endregion

        #region Propiedades
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }

       
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }

       
        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;

            }
        }
        #endregion 

        #region Constructores
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
        }
        #endregion

        #region Metodos
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return string.Format("{0} para {1}", ((Paquete)elemento).trackingID, ((Paquete)elemento).direccionEntrega);
        }


        public void MockCicloDeVida()
        {
            do
            {
                Thread.Sleep(4000);

                if (this.estado == EEstado.Ingresado)
                {
                    this.estado = EEstado.EnViaje;
                }
                else
                { 
                    if (this.estado == EEstado.EnViaje)
                    {
                        this.estado = EEstado.Entregado;
                    }
                }

                this.InformaEstado(this.estado, EventArgs.Empty);

            }while(this.estado != EEstado.Entregado);

            try
            {
                PaqueteDAO.Insertar(this);
            }

            catch (Exception e)
            {
                throw e;
            }

        }

        public override string ToString()
        {
            return this.MostrarDatos(this);
        }
        #endregion 

        #region Sobrecargas
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return p1.trackingID == p2.trackingID;         
        }
  
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        #endregion

    }
}

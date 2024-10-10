import { useEffect, useState } from "react"
import VozacService from "../../services/VozacService"
import { Button, Table } from "react-bootstrap";
import { Link, useNavigate } from "react-router-dom";
import { RouteNames } from "../../constants";


export default function VozaciPregled(){

    const navigate = useNavigate()

    const[vozaci, setVozaci] = useState();

    async function dohvatiVozaci(){
        const odgovor = await VozacService.get();
        if(odgovor.greska){
            alert(odgovor.poruka)
            return
        }
        //debugger; // ovo radi u Chrome inspect (ali i ostali preglednici)
        setVozaci(odgovor.poruka)
    } 

    // Ovaj hook (kuka) se izvodi dolaskom na stranicu Smjerovi
    useEffect(()=>{
       dohvatiVozaci();
    },[])

  
  

    function obrisi(sifra){
        if(!confirm('Sigurno obrisati')){
            return;
        }
        brisanjeVozaci(sifra)
    }

    async function brisanjeVozaci(sifra) {
        
        const odgovor = await VozacService.brisanje(sifra);
        if(odgovor.greska){
            alert(odgovor.poruka)
            return
        }
        dohvatiVozaci();
    }


    return(
        <>
        <Link to={RouteNames.VOZAC_NOVI}
        className="btn btn-success siroko">Dodaj novi vozac</Link>
        <Table striped bordered hover responsive>
            <thead>
                <tr>
                    <th>Ime</th>
                    <th>Prezime</th>
                    <th>Oib</th>    
                    <th>Akcija</th>
                </tr>
            </thead>
            <tbody>
                {vozaci && vozaci.map((vozac,index)=>(
                    <tr key={index}>
                        <td>
                            {vozac.ime}
                        </td>
                        <td>
                            {vozac.prezime}
                        </td>
                        <td>
                            {vozac.oib}
                        </td>
                       
                        <td>
                            <Button
                            variant="danger"
                            onClick={()=>obrisi(vozac.sifra)}
                            >
                                Obriši
                            </Button>
                            &nbsp;&nbsp;&nbsp;
                            <Button
                            onClick={()=>navigate(`/Vozaci/${vozac.sifra}`)}
                            >
                                Promjena
                            </Button>
                        </td>
                    </tr>
                ))}
            </tbody>
        </Table>
        </>
    )
}
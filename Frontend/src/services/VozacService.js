import { HttpService } from "./HttpService";



async function get(){
    return await HttpService.get('/Vozac')
    .then((odgovor)=>{
        //console.log(odgovor.data)
        //console.table(odgovor.data)
        return {greska: false, poruka: odgovor.data}
    })
    .catch((e)=>{
        //console.log(e)
        return {greska: true, poruka: 'Problem kod dohvaćanja vozaca'}   
    })
}

async function brisanje(sifra){
    return await HttpService.delete('/Vozac/' + sifra)
    .then(()=>{
        return {greska: false, poruka: 'Obrisano'}
    })
    .catch(()=>{
        return {greska: true, poruka: 'Problem kod brisanja vozaca'}   
    })
}

async function dodaj(vozac){
    return await HttpService.post('/Vozac',vozac)
    .then(()=>{
        return {greska: false, poruka: 'Dodano'}
    })
    .catch(()=>{
        return {greska: true, poruka: 'Problem kod dodavanja vozaca'}   
    })
}

async function promjena(sifra,vozac){
    return await HttpService.put('/Vozac/' + sifra,vozac)
    .then(()=>{
        return {greska: false, poruka: 'Dodano'}
    })
    .catch(()=>{
        return {greska: true, poruka: 'Problem kod dodavanja vozaca'}   
    })
}

async function getBySifra(sifra){
    return await HttpService.get('/Vozac/'+sifra)
    .then((odgovor)=>{
        return {greska: false, poruka: odgovor.data}
    })
    .catch((e)=>{
        return {greska: true, poruka: 'Problem kod dohvaćanja vozaca s šifrom '+sifra}   
    })
}


export default {
    get,
    brisanje,
    dodaj,
    getBySifra,
    promjena
}

import axios from 'axios';
import { CompanySearch } from './company';

interface SearchResponse {
    data: CompanySearch[];
}

export const searchCompanies = async (query:string) => {
    try{
        

        const data = await axios.get<SearchResponse>(`https://financialmodelingprep.com/api/v3/search?query=${query}&apikey=RByoNqMq3swSW3gbWSr4YoT1RktH9vBh`);
        return data;
    }catch(error){
        if(axios.isAxiosError(error)){
            console.log("error message:", error.message );
            return error.message;
        }else{
            console.log("unexpected error: ", error);
            return "an unexpected error has occured";
        }
    }
}
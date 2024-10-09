import './App.css'
import CardList from './components/cardList/CardList';
import Search from './components/search/Search';
import { ChangeEvent, useState , SyntheticEvent} from 'react';
import { CompanySearch } from './company';
import {searchCompanies} from './api';
import ListPortfolio from './components/ListPortfoilio/ListPortfolio';

function App() {

  const[search, setSearch] = useState<string>("");
  const[searchResult, setSearchResult] = useState<CompanySearch[]>([]);
  const[serverError, setServerError] = useState<string|null>(null);
  const[portfolioValues,setportfolioValues ] = useState<string[]>([]);

  const handleSearchChange = (e:ChangeEvent<HTMLInputElement>) => {
      setSearch(e.target.value);
    
  }

  const onSearchSubmit = async (e:SyntheticEvent) => {
      
    e.preventDefault();
    const result = await searchCompanies(search);
    
    if(typeof result === "string"){
        setServerError(result);
        console.log(serverError);
      }else if(Array.isArray(result.data)){
        setSearchResult(result.data);
      }
      console.log(searchResult);
  }

  const onPortfolioCreate =(e:any) => {
    e.preventDefault();
    const updatedPortfolio = [...portfolioValues,e.target[0].value];
    setportfolioValues(updatedPortfolio);
  }
  
return (
  <div>
    <Search search={search} onSearchSubmit={onSearchSubmit} handleSearchChange={handleSearchChange}/>
     <ListPortfolio portfolioValues = {portfolioValues}/>
      <CardList searchResult = {searchResult} onPortfolioCreate={onPortfolioCreate}/>
      
      {serverError && <h1 style={{color:"red"}}>Network Error</h1>}
  </div>
     
  )
}

export default App;

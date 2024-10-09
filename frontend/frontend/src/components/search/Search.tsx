import{ ChangeEvent, SyntheticEvent} from 'react'


interface Props {
   onSearchSubmit:(e:SyntheticEvent) => void;
   search: string | undefined;
   handleSearchChange:(e:ChangeEvent<HTMLInputElement>) => void;
}

const Search:React.FC<Props> = ({onSearchSubmit,handleSearchChange,search}):JSX.Element => {
   
  return (
    <div>
      <form onSubmit={onSearchSubmit}>
      <input type='text' value={search} onChange={handleSearchChange}/>
     
      </form>
        
    </div>
  )
}

export default Search
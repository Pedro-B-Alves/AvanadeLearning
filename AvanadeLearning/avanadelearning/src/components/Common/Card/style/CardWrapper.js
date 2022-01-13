
import styled, { css } from 'styled-components';
//https://www.luiztools.com.br/post/tutorial-listagem-com-busca-em-reactjs/

export const CardWrapper = styled.div`
    display: flex;
    align-items: center;
    justify-content: flex-start;
    box-shadow: 4px 4px 4px #121214;
    width: 250px;
    height: 90px;
    background-color: #121214;
    margin-top: 0.9em;
    margin-left: 1em;
    cursor: pointer;
    position: relative;
    
    .iconC{
        widht :60px;
        height: 60px;
        display: flex;
        padding-left: 10px;
        flex-direction: column;
        align-items:center;
    }
    
    
    .iconC img{
      width: 50px; 
      height: 50px;
      
    }
    
    .iText img{
      max-widht: 10px;
    }

    .iText p{
      color: #808080;
    }

    .iText{
      widht: 30px;
      heigt:30px;
      display:flex;
      align-items: center;
      
    }
    svg{
      widht: 1px ;
     color: #808080;
     // margin-bottom: 1.8em ;
     margin-bottom: 2em;
    }

    .tIcon{
      margin-top:30px;
      padding-left: 20px;
    }

    .iText p{
     
      font-family: 'poppins';
      font-size: 10px;
      padding: 0.5em 0.5em 0.5em;
    }

   

    .tIcon p{
      font-family: 'poppins';
      font-size: 11px;
    }

  input {
    border: none;
    outline: none;
    color: #ffffff;
    background-color: transparent;
    padding: 18px 0;
  }

  &:focus-within {
    border: solid 2px #FB5700;

    svg {
      color: #a8a8b3;
    }
  }
 
`;

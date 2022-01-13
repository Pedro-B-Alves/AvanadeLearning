import React from 'react';

export function Imagem({ imagem }) {
    return (
        <div>
            <img className='imgConq'
                src={`http://52.1.167.147/api/Arquivos/images/${imagem}`}
                alt="imagem da conquista"
            />
        </div>
    );
}

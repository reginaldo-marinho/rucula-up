import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import * as echarts from 'echarts';

import * as rw from 'src/app/integrante/analitics/integrante-analitics.rucula.json'
import { HttpGenericService } from '../../http-generic/http-generic.service';
import { TabulatorService } from '../../tabulator/tabulator.service';
import { Rucula } from '@reginaldo-marinho/dist/Rucula';
import { configurationRucula } from 'src/global/configurationRucula';

@Component({
  template: `<div id="js"><div>`,
  providers:[HttpGenericService]
})

export class IntegranteAnaliticsComponent implements OnInit {
   
    constructor(private http:HttpGenericService, private router: Router) {}
    
    ngOnInit(): void {
    
     let rucula = new Rucula({
        global: configurationRucula as any,
        window: rw as any,
        id: 'js'
    })

    rucula.event.on('frame.aliasFaixaEtaria.complete',(e:any) => {
      
      this.http.get('http://localhost:5270/api/IntegranteQuery')
      .subscribe(result => {
        console.log(result)
        var myChart = echarts.init(e.detail.element as HTMLElement);

        let option = {
            xAxis: {
              type: 'category',
              data: result.map((item:any) => item.faixaEtaria)
            },
            yAxis: {
              type: 'value'
            },
            series: [
              {
              data: result.map((item:any) => item.total),
                type: 'bar'
              }
            ]
          };

        myChart.setOption(option);
      })
    })

    rucula.event.on('frame.aliasMinisterio.complete',(e:any) => {

      var myChart = echarts.init(e.detail.element as HTMLElement);

      let option = {
        tooltip: {
          trigger: 'item'
        },
        legend: {
          top: '5%',
          left: 'center'
        },
        series: [
          {
            name: 'Access From',
            type: 'pie',
            radius: ['40%', '70%'],
            avoidLabelOverlap: false,
            itemStyle: {
              borderRadius: 10,
              borderColor: '#fff',
              borderWidth: 2
            },
            label: {
              show: false,
              position: 'center'
            },
            emphasis: {
              label: {
                show: true,
                fontSize: 40,
                fontWeight: 'bold'
              }
            },
            labelLine: {
              show: false
            },
            data: [
              { value: 15, name: 'Louvor' },
              { value: 34, name: 'Infantil' },
              { value: 44, name: 'Jovens e Adolescentes' },
              { value: 53, name: 'Casais' },
              { value: 33, name: 'Oração' },
              { value: 44, name: 'Ação Social' },
              { value: 6, name: 'Ensino ou Discipulado' },
              { value: 77, name: 'Missões' },
              { value: 9, name: 'Recepção e Acolhimento' },
              { value: 88, name: 'Comunicação' },
            ]
          }
        ]
      };
      myChart.setOption(option)
    })
    
      rucula.create();
    }

    

}
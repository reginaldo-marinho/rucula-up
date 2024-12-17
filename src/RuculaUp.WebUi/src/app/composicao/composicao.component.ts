import { Component, OnInit } from '@angular/core';
import * as echarts from 'echarts';

import * as rw from 'src/app/composicao/composicao.rucula.json'
import { Rucula } from '@reginaldo-marinho/dist/Rucula';
import { configurationRucula } from 'src/global/configurationRucula';
import * as data from   './data.json';

@Component({
  template: `<div id="js"><div>`,
  providers:[]
})

export class ComposicaoComponent implements OnInit {
   
    
    ngOnInit(): void {
    
     let rucula = new Rucula({
        global: configurationRucula as any,
        window: rw as any,
        id: 'js'
    })

    rucula.init()

    let composicaoData  =  JSON.parse(JSON.stringify(data)) 
    rucula.event.on('frame.aliasComposicao.complete',(e:any) => {
      
      var myChart = echarts.init(e.detail.element as HTMLElement);

      myChart.showLoading();
      myChart.hideLoading();

        let option = {
            tooltip: {
              trigger: 'item',
              triggerOn: 'mousemove'
            },
            series: [
              {
                type: 'tree',
                data: [composicaoData],
                left: '2%',
                right: '2%',
                top: '8%',
                bottom: '20%',
                symbol: 'emptyCircle',
                orient: 'vertical',
                expandAndCollapse: true,
                label: {
                  position: 'top',
                  verticalAlign: 'middle',
                  align: 'center',
                  fontSize: 9
                },
                leaves: {
                  label: {
                    position: 'bottom',
                    rotate: -90,
                    verticalAlign: 'middle',
                    align: 'left'
                  }
                },
                animationDurationUpdate: 750
              }
            ]
        }
      

      myChart.setOption(option as any);
    })

    rucula.create();
    }

    

}
import { Component } from '@angular/core';

@Component({
  selector: 'app-home-component',
  imports: [],
  templateUrl: './home-component.html',
  styleUrl: './home-component.css'
})
export class HomeComponent {
  svgns: string = "http://www.w3.org/2000/svg";
  url:string =  "/api/Shape";  //"https://localhost:7021/api/Shape";
  // url:string =  "https://localhost:7021/api/Shape";
  constructor() {


  }
  removeAllChildElements(elem : any) {
    while (elem.firstChild) {
        elem.removeChild(elem.firstChild);
    }
}
  createSVGTag(obj: any) {

    let tag = document.createElementNS(this.svgns, obj.tagType);
    for (const prop in obj.attributes) {
      tag.setAttribute(prop, obj.attributes[prop]);
    }
    if (obj.strokewidth) {
      tag.setAttribute("stroke-width", obj.strokewidth);
    }
    if (obj.textanchor) {
      tag.setAttribute("text-anchor", obj.textanchor);
    }
    if (obj.dominantbaseline) {
      tag.setAttribute("dominant-baseline", obj.dominantbaseline);
    }
    if (obj.fontsize) {
      tag.setAttribute("font-size", obj.fontsize);
    }
    if (obj.hasText) {
      const node = document.createTextNode(obj.text);
      tag.appendChild(node);
    }

    obj.elem.append(tag);
  }
  createGtag() {
    let obj : any = new Object();
    obj.elem = document.getElementById('svgroot');
    obj.tagType = "g";
    obj.attributes = new Object();
    obj.attributes.stroke = "black";
    obj.attributes.id = "gtag";
    obj.strokewidth = "1";
    this.createSVGTag(obj);
}

translateToCenter() {
    let x = window.innerWidth / 2;
    let y = window.innerHeight / 2;
    let elem = document.getElementById('gtag');
    elem?.setAttribute("transform", "translate(" + x.toString() + "," +  y.toString() + ")")
}
 circle(result : any,thisptr :any) {

    let obj : any = new Object(); 
    obj.elem = document.getElementById('gtag');
    obj.tagType = "circle";
    obj.attributes = new Object();
    obj.attributes.id = "cir1";
    obj.attributes.cx = "0";
    obj.attributes.cy = "0";
    obj.attributes.r = result.radius.toString();
    obj.attributes.fill = "green";
    thisptr.createSVGTag(obj);
    thisptr.translateToCenter();
}
Circle :Function = this.circle;
rectangle(result: any,thisptr :any) {

    let obj : any = new Object();
    obj.elem = document.getElementById('gtag');
    obj.tagType = "rect";
    obj.attributes = new Object();

    obj.attributes.id = "rect1";
    obj.attributes.x = "0";
    obj.attributes.y = "0";
    obj.attributes.width = result.width;
    obj.attributes.height = result.height;
    obj.attributes.fill = "green";
    thisptr.createSVGTag(obj);
    thisptr.translateToCenter();
}
Rectangle : Function = this.rectangle;
oval(result : any,thisptr:any) {

    let obj : any = new Object();
    obj.elem = document.getElementById('gtag');
    obj.tagType = "ellipse";
    obj.attributes = new Object();

    obj.attributes.id = "ellipse1";
    obj.attributes.cx = "0";
    obj.attributes.cy = "0";
    obj.attributes.rx = result.rx;
    obj.attributes.ry = result.ry;
    obj.attributes.fill = "green";
    thisptr.createSVGTag(obj);
    thisptr.translateToCenter();
}
Oval: Function = this.oval;
polygon(result : any,thisptr:any) {

    let obj : any = new Object();
    obj.elem = document.getElementById('gtag');
    obj.tagType = "polygon";
    obj.attributes = new Object();
    obj.attributes.id = "polygon1";
    obj.attributes.points = result.points; 
    obj.attributes.fill = "green";
    thisptr.createSVGTag(obj);
    thisptr.translateToCenter();
}
Polygon : Function = this.polygon;
draw(result : any) {
    let svgroot = document.getElementById("svgroot");
    if (svgroot) {
        svgroot.remove();
    }
    let div = document.getElementById("main");
    if (div) {
        this.removeAllChildElements(div);
        let obj: any= new Object();
        obj.tagType = "svg";
        obj.attributes = new Object();
        obj.strokewidth = "1";
        obj.attributes.id = "svgroot";
        obj.attributes.version = "2";
        obj.attributes.stroke = "black";
        obj.attributes.width = "100%";
        obj.attributes.height = window.innerHeight;
        obj.elem = div;
        this.createSVGTag(obj);
        this.createGtag();
      
         for (const key of Object.keys(this)) {
            const method = (this as any)[key]; 
            if (typeof method === 'function' && key === result.Shape) {
                method(result,this);
                break;
            }
        }

        
    }
}
  async checkDraw(event: any) {
    if(event.target.value)
    {
    let command : string =  event.target.value.toLowerCase()
    
if (command.startsWith("draw a circle with a radius of") || command.startsWith("draw a square with a side length of")
    || command.startsWith("draw an pentagon with a side length of")
    || command.startsWith("draw an hexagon with a side length of")
    || command.startsWith("draw an heptagon with a side length of")
    || command.startsWith("draw an octagon with a side length of")
    || command.startsWith("draw an isosceles triangle with a height of")
    || command.startsWith("draw a scalene triangle with a side of")
    || command.startsWith("draw a parallelogram with a side of")
    || command.startsWith("draw a equilateral triangle with a side length of")
    || command.startsWith("draw a rectangle with a width of")
    || command.startsWith("draw an oval with a x radius of")
    || command.startsWith("draw a polygon with")
) {
    const headers = { 'command': command };

    try {
        const response = await fetch(this.url, { method: 'GET', headers });
        if (response.ok) {
            let result = JSON.parse(await response.text());
            if (result.valid) {
                this.draw(result);
            }
        }

    } catch (error) {
        console.error(error);
    }
}
    }

  }

}

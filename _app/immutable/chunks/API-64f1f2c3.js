function g(e,n,a){const r=e?window.getComputedStyle(e).getPropertyValue(n):"0px";let t=m(r,a||e,a);return t=parseFloat(t)||0,parseFloat(t)}function m(e,n,a){var r;try{const c=/\(([^)]+)\)/;let t=parseFloat(e);t||(e=getComputedStyle(document.documentElement).getPropertyValue((r=c.exec(e))==null?void 0:r[1]),t=parseFloat(e));const o=a||(n!=null&&n.parentElement?n.parentElement.getBoundingClientRect():{}),l=e.replace(t,"").toLowerCase().trim(),{innerWidth:i,innerHeight:u}=window;return{["%"]:()=>Math.min((o==null?void 0:o.width)||0,(o==null?void 0:o.height)||0)*(t/100),px:()=>t,vw:()=>i*(t/100),vh:()=>u*(t/100),vmax:()=>Math.max(i,u)*(t/100),vmin:()=>Math.min(i,u)*(t/100),em:()=>parseFloat(getComputedStyle((n==null?void 0:n.parentElement)||document.body).fontSize)*t,rem:()=>parseFloat(getComputedStyle(document.body).fontSize)*t,[""]:()=>t}[l]()}catch(c){return console.error(`[CalculatePixels] could not parse ${e}:`,c.message),0}}function f(e){if(e)for(const n of e.querySelectorAll("svg *")||[])n.setAttribute("vector-effect","non-scaling-stroke")}export{g as G,f as S};
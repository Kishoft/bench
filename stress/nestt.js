
import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
  stages: [
    { duration: '1s', target: 5000 },
  ],
};

export default function () {
  const res =  http.get('http://192.168.1.38:3000/');
  check(res, { 'status was 204': (r) => r.status == 204 });
  sleep(1);
}